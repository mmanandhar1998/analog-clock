using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clock_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            int xc = ClientSize.Width / 2;
            int yc = ClientSize.Height / 2;


            int r = Math.Min(this.ClientSize.Height / 2 - 10, this.ClientSize.Width / 2 - 10);
            int d = 2 * r;
            int x = ClientSize.Width / 2-r;
            int y = ClientSize.Height / 2-r;
            g.DrawEllipse(Pens.Black,x,y,d,d);
            int sec = DateTime.Now.Second;
            int min = DateTime.Now.Minute;
            DrawSecondhandline(g, sec, r, xc, yc);




            
        }

        private void DrawSecondhandline(Graphics g,int sec,int r, int xc,int yc)
        {
            double rad = 90 - 6 * sec;
            double theta = ConvertTheta(rad);
            int xl = xc + (int)(r * Math.Sin(theta));
            int yl = yc + (int)(r * Math.Cos(theta));
            g.DrawLine(Pens.Red, xc, yc, xl, yl);
        }

        
        private void Form1_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        private double ConvertTheta(double rad)
        {
            return (rad * (Math.PI / 180));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}

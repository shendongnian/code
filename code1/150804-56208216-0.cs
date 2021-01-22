    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace Asssignment
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                
            }
    
            private void button1_Click(object sender, EventArgs e)
            { 
                Graphics g = this.CreateGraphics();
                Pen p = new Pen(Color.Blue);
                int radius = 200;
                int x =Width/2;
                int y =Height/2;
                
    
                int first_point1 = (int)(Math.Cos(0) * radius + x);
                int first_point2 = (int)(Math.Sin(0) * radius + y);
    
                Point p1= new Point(first_point1,first_point2);
                for(int i=1;i<500; i++)
                {
                    int dx = (int)(Math.Cos(i)*radius+x );
                    int dy = (int)(Math.Sin(i)*radius+y );
                    Point p2 = new Point(dx, dy);
                    g.DrawLine(p, p1, p2);
                    p1 = p2;
                }
            }
        }
    }

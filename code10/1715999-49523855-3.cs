    namespace WindowsFormsApp1
    {
        using System;
        using System.Drawing;
        using System.Drawing.Drawing2D;
        using System.Windows.Forms;
        
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                this.Cube_Panel.Paint += Cube_Panel_Paint;
                this.Cube_Panel.Resize += (s, e) => { this.Cube_Panel.Refresh(); };
            }
    
            private void Cube_Panel_Paint(object sender, PaintEventArgs e)
            {
                const double Deg2Rad = Math.PI / 180d;
                const int circle_count = 9;
    
                int cubePanelSize = Math.Min(Cube_Panel.Width, Cube_Panel.Height);
    
                int innerEllipseRadius = cubePanelSize / 4;
                int outerEllipseRadius = cubePanelSize / 3;
                int outerDotDiameter = cubePanelSize / 14;
    
                int centre_X = Cube_Panel.Width / 2;
                int centre_Y = Cube_Panel.Height / 2;
    
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                Pen p1 = new Pen(Color.Black, 1);
    
                double step = 360d / circle_count;
    
                for (double angle = 0; angle < 360d; angle += step)
                {
                    int dotCentreX = (int)(centre_X + Math.Cos(angle * Deg2Rad) * outerEllipseRadius);
                    int dotCentreY = (int)(centre_Y + Math.Sin(angle * Deg2Rad) * outerEllipseRadius);
    
                    e.Graphics.FillEllipse(Brushes.Green, new Rectangle(dotCentreX - (outerDotDiameter / 2), dotCentreY - (outerDotDiameter / 2), outerDotDiameter, outerDotDiameter));
    
                    int lineEndX = (int)(centre_X + Math.Cos(angle * Deg2Rad) * innerEllipseRadius);
                    int lineEndY = (int)(centre_Y + Math.Sin(angle * Deg2Rad) * innerEllipseRadius);
    
                    e.Graphics.DrawLine(p1, centre_X, centre_Y, lineEndX, lineEndY);
                }
    
                Graphics l = e.Graphics;
                Pen p = new Pen(Color.Gray, 5);
                l.DrawEllipse(p, centre_X - innerEllipseRadius, centre_Y - innerEllipseRadius, innerEllipseRadius * 2, innerEllipseRadius * 2);
                l.Dispose();
            }
        }
    }

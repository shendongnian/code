    namespace WindowsFormsApp1
    {
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
    
                int innerSize = cubePanelSize / 3;
                int outerSize = cubePanelSize / 10;
    
                int centre_X = Cube_Panel.Width / 2;
                int centre_Y = Cube_Panel.Height / 2;
    
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
    
                double step = 360d / circle_count;
    
                for (double angle = 0; angle < 360d; angle += step)
                {
                    int X = (int)(centre_X + Math.Cos(angle * Deg2Rad) * innerSize);
                    int Y = (int)(centre_Y + Math.Sin(angle * Deg2Rad) * innerSize);
    
                    e.Graphics.FillEllipse(Brushes.Green, new Rectangle(X - (outerSize / 2), Y - (outerSize / 2), outerSize, outerSize));
                }
    
                Graphics l = e.Graphics;
                Pen p = new Pen(Color.Gray, 5);
                l.DrawEllipse(p, centre_X - (innerSize / 2), centre_Y - (innerSize / 2), innerSize, innerSize);
                l.Dispose();
            }
        }
    }

    using System.Drawing;
    using System.Windows.Forms;
    
    namespace Question_Answer_WinForms_App
    {
        public partial class Form1 : Form
        {
            public Brush outerRectangleBrush = Brushes.DeepSkyBlue;
            public Brush innerRectangleBrush = Brushes.LightBlue;
    
            public Form1()
            {
                InitializeComponent();
                Paint += Form1_Paint;
                MouseMove += Form1_MouseMove;
            }
    
            private void Form1_MouseMove(object sender, MouseEventArgs e)
            {
                var isWithinOuterRectangle = e.Location.X >= 20
                                          && e.Location.X <= 250 + 20
                                          && e.Location.Y >= 20
                                          && e.Location.Y <= 250 + 20;
    
                var isWithinInnerRectangle = e.Location.X >= 70
                                          && e.Location.X <= 150 + 70
                                          && e.Location.Y >= 70
                                          && e.Location.Y <= 150 + 70;
    
                if (isWithinOuterRectangle)
                {
                    if (isWithinInnerRectangle)
                    {
                        outerRectangleBrush = Brushes.DeepSkyBlue;
                        innerRectangleBrush = Brushes.Red;
                        Refresh();
                    }
                    else
                    {
                        outerRectangleBrush = Brushes.Red;
                        innerRectangleBrush = Brushes.LightBlue;
                        Refresh();
                    }
                }
                else
                {
                    outerRectangleBrush = Brushes.DeepSkyBlue;
                    innerRectangleBrush = Brushes.LightBlue;
                    Refresh();
                }
            }
    
            private void Form1_Paint(object sender, PaintEventArgs e)
            {
                // Create pen.
                Pen blackPen = new Pen(Color.Black, 3);
    
                // Create rectangle.
                Rectangle rect1 = new Rectangle(20, 20, 250, 250);
                Rectangle rect2 = new Rectangle(70, 70, 150, 150);
    
                // Draw rectangle to screen.
                e.Graphics.FillRectangle(outerRectangleBrush, rect1);
                e.Graphics.FillRectangle(innerRectangleBrush, rect2);
            }
        }
    }

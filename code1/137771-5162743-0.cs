       public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            List<Point> points = new List<Point>();
    
            private void Form1_MouseMove(object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left)
                {
                    points.Add(e.Location);
    
                    Invalidate();
                }
            }
    
            private void Form1_Paint(object sender, PaintEventArgs e)
            {
                if (points.Count > 2)
                {
                    e.Graphics.DrawLines(Pens.Black, points.ToArray());
                }
            }
        }

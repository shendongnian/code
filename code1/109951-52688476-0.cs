         private void DrawEllipseRectangle(PaintEventArgs e)
            {
                Pen p = new Pen(Color.Black, 3);
                Rectangle r = new Rectangle(100, 100, 100, 100);
                e.Graphics.DrawEllipse(p, r);
            }
         private void Form1_Paint(object sender, PaintEventArgs e)
            {
                DrawEllipseRectangle(e);
            }

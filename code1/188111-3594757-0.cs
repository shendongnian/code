    private Point p1, p2;
        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (p1.X == 0)
            {
                p1.X = e.X;
                p1.Y = e.Y;
            }
            else
            {
                p2.X = e.X;
                p2.Y = e.Y;
                Graphics graph = this.CreateGraphics();
                Pen penCurrent = new Pen(Color.Red, 3);
                graph.DrawLine(penCurrent, p1, p2);
            }
        }

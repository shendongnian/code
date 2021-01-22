        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.Clear(BackColor);
            GraphicsPath p = new GraphicsPath();
            // add the desired path
            p.AddPie(100, 100, 100, 100, 0, 270);
            
            // add the rectangle to invert the inside
            p.AddRectangle(new Rectangle(50, 50, 200, 200));
            g.FillPath(Brushes.Black, p);
        }

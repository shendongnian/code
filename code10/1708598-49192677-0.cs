    class ArrowButton : Button
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            float h = this.Height;
            float w = this.Width;
            // This defines the shape of the triangle
            // This is an upwards pointing triangle
            PointF[] pts = new PointF[] { new PointF(w / 2, 0), new PointF(0, w), new PointF(w, h) };
            // This points down
            //PointF[] pts = new PointF[] { new PointF(0, 0), new PointF(w, 0), new PointF(w / 2, h) };
            // Paints the triangle a grey colour
            g.FillPolygon(Brushes.Gray, pts);
            GraphicsPath gp = new GraphicsPath();
            gp.AddPolygon(pts);
            this.Region = new Region(gp);
        }
    }

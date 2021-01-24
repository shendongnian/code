        protected override void OnPaint(PaintEventArgs e) {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            DrawIt(e.Graphics);
        }
        private void DrawIt(Graphics graphics) {
            var text = "123";
            var font = new Font("Arial", 40);
            // Build a path containing the text in the desired font, and get its bounds.
            GraphicsPath path = new GraphicsPath();
            path.AddString(text, font.FontFamily, (int)font.Style, font.SizeInPoints, new Point(0, 0), StringFormat.GenericDefault);
            var bounds = path.GetBounds();
            // Move it where I want it.
            var xlate = new Matrix();
            xlate.Translate(100, 100);
            path.Transform(xlate);
            // Draw the path (and a bounding rectangle).
            graphics.DrawPath(Pens.Black, path);
            bounds = path.GetBounds();
            graphics.DrawRectangle(Pens.Blue, bounds.Left, bounds.Top, bounds.Width, bounds.Height);
        }

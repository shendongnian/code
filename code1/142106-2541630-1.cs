        private void panel1_Scroll(object sender, ScrollEventArgs e) {
            panel2.Invalidate();
        }
        private void panel2_Paint(object sender, PaintEventArgs e) {
            Point pos = new Point(panel1.AutoScrollPosition.X, 0);
            TextRenderer.DrawText(e.Graphics, "nobugz waz here", panel2.Font, pos, Color.Black);
            // Draw something
            e.Graphics.TranslateTransform(pos.X, pos.Y);
            e.Graphics.DrawLine(Pens.Black, 0, 0, 100, 100);
        }

            private void dropShadow(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Panel panel = (Panel)sender;
            Pen pen=null;
            Point pt;
            Color[] shadow = new Color[3];
            shadow[0] = Color.FromArgb(181, 181, 181);
            shadow[1] = Color.FromArgb(195, 195, 195);
            shadow[2] = Color.FromArgb(211, 211, 211);
            foreach(Panel p in panel.Controls.OfType<Panel>())
            {
                pt = p.Location;
                pt.Y += p.Height;
                for (var sp = 0; sp<3; sp++)
                {
                    pen = new Pen(shadow[sp]);
                    g.DrawLine(pen, pt.X, pt.Y, pt.X + p.Width, pt.Y);
                    pt.Y++;
                }
            }
            pen.Dispose();
            g.Dispose();
        }

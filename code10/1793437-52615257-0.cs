            private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            foreach (var rect in rects)
            {
                
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.DrawEllipse(magenta,rect);
            }
        }

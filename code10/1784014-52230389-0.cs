        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                p2 = e.Location;
                Graphics g = pictureBox1.CreateGraphics();
                g.DrawLine(pen, p1, p2);
                g.Dispose();
            }
        }

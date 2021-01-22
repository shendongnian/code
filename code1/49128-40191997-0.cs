        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            using (Pen p = new Pen(Brushes.Black))
            {
                p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                e.Graphics.DrawLine(p, 10, 10, 11, 10);
            }
        }

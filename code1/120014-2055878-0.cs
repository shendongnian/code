        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Bitmap bmp = new Bitmap(300, 300);
            Graphics g = Graphics.FromImage(bmp);
            g.FillRectangle(new SolidBrush(Color.White), 0, 0, 300, 300);
            g.FillRectangle(new SolidBrush(Color.Red), 100, 100, 100, 100);
            pictureBox1.Image = bmp;
            Brush brush = new SolidBrush(Color.FromArgb(150, 0, 80, 0));
            g.DrawRectangle(Pens.Black, 50, 50, 200, 200);
            g.FillRectangle(brush, 50, 50, 200, 200);
        }

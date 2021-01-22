    Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
    using (Graphics g = Graphics.FromImage(bmp))
    {
        g.DrawLine(new Pen(Color.Red), 0, 0, 10, 10);
    }
    pictureBox1.Image = bmp;

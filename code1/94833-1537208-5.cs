    private Point? _Previous = null;
    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
        _Previous = new Point(e.X, e.Y);
        pictureBox1_MouseMove(sender, e);
    }
    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        if (_Previous != null)
        {
            if (pictureBox1.Image == null)
            {
                Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.White);
                }
                pictureBox1.Image = bmp;
            }
            using (Graphics g = Graphics.FromImage(pictureBox1.Image))
            {
                Pen pen = new Pen(Color.Black);
                g.DrawLine(pen, _Previous.Value, new Point(e.X, e.Y));
            }
            pictureBox1.Invalidate();
            _Previous = new Point(e.X, e.Y);
        }
    }
    private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
    {
        _Previous = null;
    }

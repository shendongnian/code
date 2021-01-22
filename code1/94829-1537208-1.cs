    private Point? _Previous = null;
    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
        _Previous = e.Location;
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
                g.DrawLine(Pens.Black, _Previous.Value, e.Location);
            }
            pictureBox1.Invalidate();
            _Previous = e.Location;
        }
    }
    private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
    {
        _Previous = null;
    }

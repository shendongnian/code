    private void pictureBox1_Paint (object sender, PaintEventArgs e)
    {
       using (SolidBrush b = new SolidBrush(Color.FromArgb(128, Color.White))
       {
           e.Graphics.FillRectangle (b, 0, 0, pictureBox1.Width, pictureBox1.Height);
       }

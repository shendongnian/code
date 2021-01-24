    private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
    {
        Bitmap bit = new Bitmap(pictureBox1.Image);
        MessageBox.Show(bit.GetPixel(e.X, e.Y).Name);
    }

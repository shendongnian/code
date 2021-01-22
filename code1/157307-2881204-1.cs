    private void pictureBox1_SizeChanged(object sender, EventArgs e)
    {
        if ((pictureBox1.Image != null))
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Image, pictureBox1.Size);
        }
    }

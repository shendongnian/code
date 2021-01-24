    private void button1_Click(object sender, EventArgs e)
    {
        using (FileStream stream = File.OpenRead(FullName))
        {
            pictureBox1.Image = Bitmap.FromStream(stream);
        }
        using (Graphics g = Graphics.FromImage(pictureBox1.Image))
        {
            g.Clear(Color.FromArgb(0, 255, 255, 255));
        }
    }  

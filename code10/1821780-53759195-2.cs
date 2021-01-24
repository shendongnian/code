    using (FileStream stream = File.OpenRead(FullName)
    {
        pictureBox1.Image = (Image)Image.FromStream(stream).Clone();
        using (Graphics g = Graphics.FromImage(pictureBox1.Image))
        {
            g.Clear(Color.FromArgb(0, 255, 255, 255));
        }
    }

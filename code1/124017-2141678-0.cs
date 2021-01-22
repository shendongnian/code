    lock (locker)
    {
        Graphics gr = Graphics.FromImage(bmp2);
        gr.DrawImage(Resources.someImage, new Rectangle(0, 0, 800, 600));
        gr.Dispose();
        pictureBox1.Invoke(new Action(() => pictureBox1.Image = bmp2));
    }

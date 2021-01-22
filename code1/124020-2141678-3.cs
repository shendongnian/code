    lock (locker)
    {
        using (Graphics gr = Graphics.FromImage(bmp2))
        {
            gr.DrawImage(Resources.someImage, new Rectangle(0, 0, 800, 600));
            var clone = bmp2.Clone() as Image;
            pictureBox1.Invoke(new Action(() => pictureBox1.Image = clone));
        }
    }

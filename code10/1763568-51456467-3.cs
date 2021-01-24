    using (Bitmap imageSource = (Bitmap)Image.FromFile(@"[SomeImageOfLena]"))
    using (Bitmap imageCopy = new Bitmap(imageSource.Width + 100, imageSource.Height, imageSource.PixelFormat))
    {
        imageCopy.SetResolution(imageSource.HorizontalResolution, imageSource.VerticalResolution);
        using (Graphics g = Graphics.FromImage(imageCopy))
        {
            g.Clear(Color.Black);
            g.CompositingMode = CompositingMode.SourceCopy;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(imageSource, (imageCopy.Width - imageSource.Width) / 2, 0);
            pictureBox1.Image = (Image)imageSource.Clone();
            pictureBox2.Image = (Image)imageCopy.Clone();
        }
    }

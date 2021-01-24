    Size sz = pictureBox1.ClientSize;
    using (Bitmap bmp = new Bitmap(sz.Width, sz.Height))
    {
        pictureBox1.DrawToBitmap(bmp, pictureBox1.ClientRectangle);
        // save the image..
        bmp.Save(yourfilepath, ImageFormat.Png);
        // ..or print it!
    }

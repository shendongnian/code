    var selectedRectangle = new Rectangle(100, 100, 100, 100);
    var result = GetRectangeOnImage(pictureBox1, selectedRectangle);
    using (var bm = new Bitmap((int)result.Width, (int)result.Height))
    {
        using (var g = Graphics.FromImage(bm))
            g.DrawImage(pictureBox1.Image, 0, 0, result, GraphicsUnit.Pixel);
        pictureBox2.Image = (Image)bm.Clone();
    }

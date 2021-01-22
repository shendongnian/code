    private void SaveControlImage(Control ctr)
    {
        try
        {
            var imagePath = @"C:\Image.png";
            Image bmp = new Bitmap(ctr.Width, ctr.Height);
            var gg = Graphics.FromImage(bmp);
            var rect = ctr.RectangleToScreen(ctr.ClientRectangle);
            gg.CopyFromScreen(rect.Location, Point.Empty, ctr.Size);
            bmp.Save(imagePath);
            Process.Start(imagePath);
        }
        catch (Exception)
        {
            //
        }
    }

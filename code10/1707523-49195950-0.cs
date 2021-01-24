    var imageMetafile = new Bitmap(this.Width, this.Height);
    using (Graphics imageGraphics = Graphics.FromImage(imageMetafile))
    {
        imageGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        imageGraphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
        imageGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, this.Size);
        imageMetafile.Save(Environment.GetFolderPath(filepath);
    }

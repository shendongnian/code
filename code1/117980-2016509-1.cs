    Bitmap orig = new Bitmap(@"c:\temp\24bpp.bmp");
    Bitmap clone = new Bitmap(orig.Width, orig.Height,
        System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
    using (Graphics gr = Graphics.FromImage(clone)) {
        gr.DrawImage(orig, new Rectangle(0, 0, clone.Width, clone.Height));
    }
    
    // Dispose orig as necessary...

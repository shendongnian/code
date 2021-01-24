    using TGASharpLib;
    ....
    TGA T;
    private void ConvertButton_Click(object sender, EventArgs e)
        {
            using (Bitmap original = new Bitmap("file.path.jpg"))
            using (Bitmap clone = new Bitmap(original))
            using (Bitmap newbmp = clone.Clone(new Rectangle(0, 0, clone.Width, clone.Height), PixelFormat.Format32bppArgb))
            T = (TGA)newbmp;
            T.Save("file.path.cover.tga");
        }

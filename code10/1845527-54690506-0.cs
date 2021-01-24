    private void btnSaveImage_Click(object sender, EventArgs e)
    {
       int width = panel.Size.Width;
       int height = panel.Size.Height;
       Bitmap bm = new Bitmap(width, height);
       panel.DrawToBitmap(bm, new Rectangle(0, 0, width, height));
       bm.Save(@"D:\TestDrawToBitmap.png", ImageFormat.Png);
    }

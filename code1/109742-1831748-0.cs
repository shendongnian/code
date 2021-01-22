    if (pic.Image != null)
    {
        pic.Image.Dispose();
    }
    pic.Image = System.Drawing.Image.FromHbitmap(bmp.GetHbitmap());

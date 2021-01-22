    using(Image img = Image.FromFile(@"C:\path\to\img.jpg"))
    {
        if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Jpeg))
        {
          // ...
        }
    }

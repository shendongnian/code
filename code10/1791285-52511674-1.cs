    Image img = Image.FromFile(@"C:\Lenna.jpg");
    byte[] arr;
    using (MemoryStream ms = new MemoryStream())
    {
        img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
        arr =  ms.ToArray();
    }

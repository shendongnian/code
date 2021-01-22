    string imageBase64;
    using (Image image = Image.FromFile(@"C:\path_to_image.jpg"))
    {
        using (MemoryStream ms = new MemoryStream())
        {
            image.Save(ms, ImageFormat.Jpeg);
            imageBase64 = Convert.ToBase64String(ms.ToArray());
        }
    }
    Console.WriteLine(imageBase64.Length);
    byte[] imageData = Convert.FromBase64String(imageBase64);
    using (MemoryStream ms = new MemoryStream(imageData))
    {
        using (Image image = Image.FromStream(ms))
        {
            Console.WriteLine(image.Width);
        }
    }

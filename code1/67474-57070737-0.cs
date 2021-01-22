    for (int i = 1; i <= 1000; i++)
    {
       Image newImage = Image.FromFile(@"Sample.tif");
       //...some logic here
       newImage.Save(i + ".tif", , ImageFormat.Tiff);
    }

    var imagePath = @"C:\test.bmp";
    
    Bitmap b = new Bitmap(100, 100);
    
    for (int pixelXCounter = 0; pixelXCounter < 100; pixelXCounter++) {
        for (int pixelYCounter = 0; pixelYCounter < 100; pixelYCounter++)
        {
            b.SetPixel(pixelXCounter, pixelYCounter, System.Drawing.Color.Salmon);
        } }
    
    b.Save(imagePath, System.Drawing.Imaging.ImageFormat.Bmp);

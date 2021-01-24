    var image = Image.FromFile(mySourceImageFile);
    var bmp = new Bitmap(240, 240);
    var tempBmp = new Bitmap(image.Width + 4, image.Height + 5);
        
    using (var g = Graphics.FromImage(tempBmp))
    {
        g.DrawImage(image, 0, 0);
        g.DrawImage(image, 4, 0);
        g.DrawImage(image, 0, 5);
        g.DrawImage(image, 4, 5);
        g.DrawImage(image, 2, 0);
        g.DrawImage(image, 2, 1);        
        g.DrawImage(image, 0, 2);
        g.DrawImage(image, 1, 2);
        g.DrawImage(image, 4, 2);
        g.DrawImage(image, 3, 2);        
        g.DrawImage(image, 2, 5);
        g.DrawImage(image, 2, 4);
        g.DrawImage(image, 2, 3);
        g.DrawImage(image, 2, 2);
    }
    using (var g = Graphics.FromImage(bmp))
    {
        // ... some other codes
        g.Clear(Color.Aqua); // I use this to highlight whole image
        // ... some other codes
        var imageRect = new Rectangle(2, 2, image.Width, image.Height);
        var drawRect = new Rectangle(0, 0, bmp.Width, bmp.Height);
        g.DrawImage(tempBmp, drawRect, imageRect, GraphicsUnit.Pixel);
        // ... some other codes
    }
    
    bmp.Save(myDestinationImageFile);

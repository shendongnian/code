    var newImage = new Bitmap(original.Width, original.Height, original.PixelFormat);
    
    using(var g = Graphics.FromImage(newImage)) {
        var matrix = new ColorMatrix(new[] {
            new float[] { 1.0f, 0.0f, 0.0f, 0.0f, 0.0f },
            new float[] { 0.0f, 1.0f, 0.0f, 0.0f, 0.0f },
            new float[] { 0.0f, 0.0f, 1.0f, 0.0f, 0.0f },
            new float[] { 0.0f, 0.0f, 0.0f, 1.0f, 0.0f },
            new float[] { 1.0f, 1.0f, 1.0f, 0.0f, 1.0f }
        });
    
        var attributes = new ImageAttributes();
    
        attributes.SetColorMatrix(matrix);
    
        g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height), 0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);
    }

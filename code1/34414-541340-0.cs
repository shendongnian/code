        // Retrieve the image.
        var image1 = new Bitmap(@"C:\Documents and Settings\All Users\" 
            + @"Documents\My Music\music.bmp", true);
        int x, y;
        // Loop through the images pixels to reset color.
        for(x=0; x<image1.Width; x++)
        {
            for(y=0; y<image1.Height; y++)
            {
                Color pixelColor = image1.GetPixel(x, y);
                Color newColor = Color.FromArgb(0xff - pixelColor.R
				, 0xff - pixelColor.G, 0xff - pixelColor.B);
                image1.SetPixel(x, y, newColor);
            }
        }

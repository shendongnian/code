    bool HasGreen(int tolerance)
    {
        using (var bmp = new Bitmap(Image.FromFile(@"c:\file.bmp")))
        {            
            for (int w = 0; w < bmp.Width; w++)
            for (int h = 0; w < bmp.Height; h++)
                if (IsGreenPixel(bmp.GetPixel(w, h), tolerance))
                    return true;
        }
        return false;
    }
    bool IsGreenPixel(Color color, int tolerance) 
        => color.G > color.R + tolerance && color.G > color.B + tolerance;

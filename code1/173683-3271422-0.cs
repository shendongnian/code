    public Bitmap CropBitmap(Bitmap original)
    {
        // determine new left
        int newLeft = -1;
        for (int x = 0; x < original.Width; x++)
        {
            for (int y = 0; y < original.Height; y++)
            {
                Color color = original.GetPixel(x, y);
                if ((color.R != 0) || (color.G != 0) || (color.B != 0) || 
                    (color.A != 0))
                {
                    // this pixel is either not white or not fully transparent
                    newLeft = x;
                    break;
                }
            }
            if (newLeft != -1)
            {
                break;
            }
    
            // repeat logic for new right, top and bottom
    
        }
    
        Bitmap ret = new Bitmap(newRight - newLeft, newTop - newBottom);
        using (Graphics g = Graphics.FromImage(ret)
        {
            // copy from the original onto the new, using the new coordinates as
            // source coordinates for the original
            g.DrawImage(...);
        }
    
        return ret
    }

    public Bitmap Quantize(Image source)
    {
        // Get the size of the source image
        int height = source.Height;
        int width = source.Width;
        // And construct a rectangle from these dimensions
        Rectangle bounds = new Rectangle(0, 0, width, height);
        // First off take a 32bpp copy of the image
        Bitmap copy = new Bitmap(width, height, PixelFormat.Format32bppArgb);
        // And construct an 8bpp version
        Bitmap output = new Bitmap(width, height, PixelFormat.Format8bppIndexed);
        // Now lock the bitmap into memory
        using (Graphics g = Graphics.FromImage(copy))
        {
            g.PageUnit = GraphicsUnit.Pixel;
            // Draw the source image onto the copy bitmap,
            // which will effect a widening as appropriate.
                g.DrawImage(source, bounds);
        }
        //!! BEGIN CHANGES - no locking here
        //!! simply use copy not a pointer to it
        //!! you could also simply write directly to a buffer then make the final immage in one go but I don't bother here
            
        // Call the FirstPass function if not a single pass algorithm.
        // For something like an octree quantizer, this will run through
        // all image pixels, build a data structure, and create a palette.
        if (!_singlePass)
            FirstPass(copy, width, height);
        // Then set the color palette on the output bitmap. I'm passing in the current palette 
        // as there's no way to construct a new, empty palette.
        output.Palette = GetPalette(output.Palette);
        // Then call the second pass which actually does the conversion
        SecondPass(copy, output, width, height, bounds);
        //!! END CHANGES
        // Last but not least, return the output bitmap
        return output;
    }
    //!! Completely changed, note that I assume all the code is changed to just use Color rather than Color32
    protected  virtual void FirstPass(Bitmap source, int width, int height)
    {
        // Loop through each row
        for (int row = 0; row < height; row++)
        {
            // And loop through each column
            for (int col = 0; col < width; col++)
            {            
                InitialQuantizePixel(source.GetPixel(col, row)); 
            }	// Now I have the pixel, call the FirstPassQuantize function...
        }
    }

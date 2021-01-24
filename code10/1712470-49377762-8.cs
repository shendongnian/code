    public static Bitmap GrayImageFromCsv(String[] lines, Int32 startColumn, Int32 maxValue)
    {
        // maxValue cannot exceed 255
        maxValue = Math.Min(maxValue, 255);
        // Read lines; this gives us the data, and the height.
        //String[] lines = File.ReadAllLines(path);
        if (lines == null || lines.Length == 0)
            return null;
        Int32 bottom = lines.Length;
        // Trim any empty lines from the start and end.
        while (bottom > 0 && lines[bottom - 1].Trim().Length == 0)
            bottom--;
        if (bottom == 0)
            return null;
        Int32 top = 0;
        while (top < bottom && lines[top].Trim().Length == 0)
            top++;
        Int32 height = bottom - top;
        // This removes the top-bottom stuff; the new array is compact.
        String[][] values = new String[height][];
        for (Int32 i = top; i < bottom; i++)
            values[i - top] = lines[i].Split(',');
        // Find width: maximum csv line length minus the amount of columns to skip.
        Int32 width = values.Max(line => line.Length) - startColumn;
        if (width <= 0)
            return null;
        // Create the array. Since it's 8-bit, this is one byte per pixel.
        Byte[] imageArray = new Byte[width*height];
        // Parse all values into the array
        // Y = lines, X = csv values
        for (Int32 y = 0; y < height; y++)
        {
            Int32 offset = y*width;
            // Skip indices before "startColumn". Target offset starts from the start of the line anyway.
            for (Int32 x = startColumn; x < values[y].Length; x++)
            {
                Int32 val;
                // Don't know if Trim is needed here. Depends on the file.
                if (Int32.TryParse(values[y][x].Trim(), out val))
                    imageArray[offset] = (Byte) Math.Max(0, Math.Min(val, maxValue));
                offset++;
            }
        }
        // generate gray palette for the given range, by calculating the factor to multiply by.
        Double mulFactor = 255d / maxValue;
        Color[] palette = new Color[maxValue + 1];
        for (Int32 i = 0; i <= maxValue; i++)
        {
            // Away from zero rounding: 2.4 => 2 ; 2.5 => 3
            Byte g = (Byte)Math.Round(i * mulFactor, MidpointRounding.AwayFromZero);
            palette[i] = Color.FromArgb(g, g, g);
        }
        // Since the palette is incomplete, give the color fill arg as Color.White
        return BuildImage(imageArray, width, height, width, PixelFormat.Format8bppIndexed, palette, Color.White);
    }

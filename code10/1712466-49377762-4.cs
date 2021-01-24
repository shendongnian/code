    public static Bitmap GrayImageFromCsv(String[] lines, Int32 startColumn)
    {
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
        Byte[] imageArray = new Byte[width * height];
        // Parse all values into the array
        // Y = lines, X = csv values
        for (Int32 y = 0; y < height; y++)
        {
            Int32 offset = y * width;
            // Skip indices before "startColumn". Target offset starts from the start of the line anyway.
            for (Int32 x = startColumn; x < values[y].Length; x++)
            {
                Byte val;
                // Don't know if Trim is needed here. Depends on the file.
                if (Byte.TryParse(values[y][x].Trim(), out val))
                    imageArray[offset] = val;
                offset++;
            }
        }
        // generate gray palette
        Color[] palette = new Color[0x100];
        for (Int32 i = 0; i < 0x100; i++)
            palette[i] = Color.FromArgb(i, i, i);
        return ImageUtils.BuildImage(imageArray, width, height, width, PixelFormat.Format8bppIndexed, palette, null);
    }

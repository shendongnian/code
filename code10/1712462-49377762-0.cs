    public static Bitmap fromCsv(String path)
    {
        // Read lines; this gives us the data, and the height.
        String[] lines = File.ReadAllLines(path);
        if (lines.Length == 0)
            return null;
        Int32 height = lines.Length;
        // Trim any empty lines from the end. Not gonna do the same for the top; that'd complicate things too much.
        while (lines[height - 1].Equals(String.Empty) && height > 0)
            height--;
        if (height <= 0)
            return null;
        String[][] values = new String[height][];
        for (Int32 i = 0; i < height; i++)
            values[i] = lines[i].Split(',');
        // Find width: maximum csv line length minus three
        Int32 width = values.Max(line => line.Length) - 3;
        if (height <= 0)
            return null;
        // Create the array. Since it's 8-bit, this is one byte per pixel.
        Byte[] imageArray = new Byte[width * height];
        // Parse all values into the array
        // Y = lines, X = csv values
        for (Int32 y = 0; y < values.Length; y++)
        {
            Int32 offset = y*width;
            // Skip first three indices
            for (Int32 x = 3; x < values[y].Length; x++)
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

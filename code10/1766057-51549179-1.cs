    private static List<Color> GetLotsOfColors(int gap)
    {
        gap = gap < 16 ? 16 : gap;
        List<Color> ColorList = new List<Color>();
        for (int r = 0; r < 256; r += gap)
        {
            for (int g = 0; g < 256; g += gap)
            {
                for (int b = 0; b < 256; b += gap)
                {
                    for (int a = 0; a < 256; a += gap)
                    {
                        ColorList.Add(Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b));
                    }
                }
            }
        }
        return ColorList;
    }

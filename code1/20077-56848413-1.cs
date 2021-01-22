    [DllImport("shlwapi.dll")]
    public static extern int ColorHLSToRGB(int H, int L, int S);
    public static string GetRandomDarkColor()
    {
        int h = 0, s = 0, l = 0;
        h = (RandomObject.Next(1, 2) % 2 == 0) ? RandomObject.Next(0, 180) : iApp.RandomObject.Next(181, 360);
        s = RandomObject.Next(90, 160);
        l = RandomObject.Next(80, 130);
        return System.Drawing.ColorTranslator.FromWin32(ColorHLSToRGB(h, l, s)).ToHex();
    }
    private static string ToHex(this System.Drawing.Color c)
    {
        return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
    }

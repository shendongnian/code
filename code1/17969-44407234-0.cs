    private static readonly string[] UNITS = new string[] { "B", "KB", "MB", "GB", "TB", "PB", "EB" };
    public static string FormatSize(ulong bytes)
    {
        int c = 0;
        for (c = 0; c < UNITS.Length; c++)
        {
            ulong m = (ulong)1 << ((c + 1) * 10);
            if (bytes < m)
                break;
        }
        double n = bytes / (double)((ulong)1 << (c * 10));
        return string.Format("{0:0.##} {1}", n, UNITS[c]);
    }

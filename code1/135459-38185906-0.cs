    private static string HexConverter(Color c) {
      return String.Format("#{0:X6}", c.ToArgb() & 0x00FFFFFF);
    }
    public static string RgbConverter(Color c) {
      return String.Format("RGB({0},{1},{2})", c.R, c.G, c.B);
    }

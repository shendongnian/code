    public static int (this System.Windows.Media.Color color)
    {
       byte[] bytes = new byte[] { color.A, color.R, color.G, color.B };
       return BitConverter.ToInt32(bytes, 0);
    }

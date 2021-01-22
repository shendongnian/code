    public static Color Invert(this Color c) => Color.FromArgb(c.R.Invert(), c.G.Invert(), c.B.Invert());
    public static byte Invert(this byte b) {
        unchecked {
            return (byte)(b + 128);
        }
    }

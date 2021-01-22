    public static Color ToColor(this uint argb)
    {
        return Color.FromArgb(unchecked((int)argb));
    }
    public static Color ToColor(this int argb)
    {
        return Color.FromArgb(argb);
    }

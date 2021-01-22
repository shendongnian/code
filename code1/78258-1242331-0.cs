    public static double BytesToKilobytes(this Int32 bytes)
    {
        return bytes / 1024d;
    }
    public static double BytesToMegabytes(this Int32 bytes)
    {
        return bytes / 1024d / 1024d;
    }
    public static double KilobytesToBytes(this double kilobytes)
    {
        return kilobytes / 1024d;
    }
    //You can then do something like:
    double filesize = 32.5d;
    double bytes = filesize.KilobytesToBytes();

    public const int SPI_SETDESKWALLPAPER = 20;
    public const int SPIF_UPDATEINIFILE = 1;
    public const int SPIF_SENDCHANGE = 2;
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern int SystemParametersInfo(
      int uAction, int uParam, string lpvParam, int fuWinIni);

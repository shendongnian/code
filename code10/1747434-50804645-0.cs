    public static void clearDesktop()
        {
            SetDesktopWallpaper(GetDesktopWallpaper());
        }
        private static readonly int MAX_PATH = 260;
        private static readonly int SPI_GETDESKWALLPAPER = 0x73;
        private static readonly int SPI_SETDESKWALLPAPER = 0x14;
        private static readonly int SPIF_UPDATEINIFILE = 0x01;
        private static readonly int SPIF_SENDWININICHANGE = 0x02;
        static string GetDesktopWallpaper()
        {
            string wallpaper = new string('\0', MAX_PATH);
            W32.SystemParametersInfo(SPI_GETDESKWALLPAPER, wallpaper.Length, wallpaper, 0);
            return wallpaper.Substring(0, wallpaper.IndexOf('\0'));
        }
        static void SetDesktopWallpaper(string filename)
        {
            W32.SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, filename,
                SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
        }

    public class ChangeWallpaper
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);
        public static void Main()
        {
            Bitmap bm = new Bitmap(Image.FromFile("pic.jpg"));
            bm.Save("pic.bmp", ImageFormat.Bmp);
            SystemParametersInfo(20, 0, "pic.bmp", 0x01 | 0x02);
        }
    }

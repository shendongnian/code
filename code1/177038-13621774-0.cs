    public class IconTools
    {
        private class IconToolsAxHost : System.Windows.Forms.AxHost
        {
            private IconToolsAxHost() : base(string.Empty) { }
            public static stdole.IPictureDisp GetIPictureDispFromImage(System.Drawing.Image image)
            {
                return (stdole.IPictureDisp)GetIPictureDispFromPicture(image);
            }
            public static System.Drawing.Image GetImageFromIPicture(object iPicture)
            {
                return GetPictureFromIPicture(iPicture);
            }
        }
        public static stdole.IPictureDisp GetIPictureDisp(System.Drawing.Image image)
        {
            return IconToolsAxHost.GetIPictureDispFromImage(image);
        }
        public static System.Drawing.Image GetImage(stdole.IPicture iPicture)
        {
            return IconToolsAxHost.GetImageFromIPicture(iPicture);
        }
        public static System.Drawing.Image GetImage(stdole.IPictureDisp iPictureDisp)
        {
            return IconToolsAxHost.GetImageFromIPicture(iPictureDisp);
        }
    }

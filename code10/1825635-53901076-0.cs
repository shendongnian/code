    private void TakeScreenShot()
    {
        double Left = SystemParameters.VirtualScreenLeft;
        double Top = SystemParameters.VirtualScreenTop;
        double ScreenWidth = SystemParameters.VirtualScreenWidth;
        double ScreenHeight = SystemParameters.VirtualScreenHeight;
        System.Drawing.Bitmap bmpScreen = new System.Drawing.Bitmap(ScreenWidth, ScreenHeight);
        System.Drawing.Graphics graphic = System.Drawing.Graphics.FromImage(bmpScreen);
        graphic.CopyFromScreen(Left, Top, 0, 0, bmpScreen.Size);
        bmpScreen.Save("Path to save");
    }

    private void TakeScreenShot()
    {
        double Left = SystemParameters.VirtualScreenLeft;
        double Top = SystemParameters.VirtualScreenTop;
        double ScreenWidth = SystemParameters.VirtualScreenWidth;
        double ScreenHeight = SystemParameters.VirtualScreenHeight;
        using (System.Drawing.Bitmap bmpScreen = new System.Drawing.Bitmap((int)ScreenWidth, (int)ScreenHeight))
        {
           using (System.Drawing.Graphics graphic = System.Drawing.Graphics.FromImage(bmpScreen))
           {
                graphic.CopyFromScreen((int)Left, (int)Top, 0, 0, bmpScreen.Size);
                bmpScreen.Save(@"D:\bitmap.bmp");
                IMG.Source = BitmapToImageSource(bmpScreen); // show bitmap in IMG (Image control)
            }
        }
    }
    BitmapImage BitmapToImageSource(Bitmap bitmap)
    {
        using (MemoryStream memory = new MemoryStream())
        {
            bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
            memory.Position = 0;
            BitmapImage bitmapimage = new BitmapImage();
            bitmapimage.BeginInit();
            bitmapimage.StreamSource = memory;
            bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapimage.EndInit();
            return bitmapimage;
        }
    }

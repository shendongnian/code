    [DllImport("user32.dll", CharSet = CharSet.Auto)]
            private static extern Int32 SystemParametersInfo(UInt32 action, UInt32 uParam, String vParam, UInt32 winIni);
            private static readonly UInt32 SPI_SETDESKWALLPAPER = 0x14;
            private static readonly UInt32 SPIF_UPDATEINIFILE = 0x01;
            private static readonly UInt32 SPIF_SENDWININICHANGE = 0x02;
    
            private void SetWallpaper(string path)
            {
                if (File.Exists(path))
                {
                    Image imgInFile = Image.FromFile(path);
                    try
                    {
                        imgInFile.Save(SaveFile, ImageFormat.Bmp);
                        SystemParametersInfo(SPI_SETDESKWALLPAPER, 3, SaveFile, SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
                    }
                    catch
                    {
                        MessageBox.Show("error in setting the wallpaper");
                    }
                    finally
                    {
                        imgInFile.Dispose();
                    }
                }
            }

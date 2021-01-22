    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using Microsoft.Win32;
    using System.Windows.Forms;
    
    
    namespace toolbox.Wallpaper
    {
        public class CustomWally
        {        
            const int SetDeskWallpaper = 20;
            const int UpdateIniFile = 0x01;
            const int SendWinIniChange = 0x02;
            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);
                      
            double ratio;
            public CustomWally()
            {
                int Width = Screen.PrimaryScreen.Bounds.Width;
                int Height = Screen.PrimaryScreen.Bounds.Height;
                ratio = 1.0 * Width / Height;
    
                foreach (Screen scr in Screen.AllScreens)
                {
                    images.Add(scr.DeviceName, null);
                    screenos.Add(scr.DeviceName);
                }
            }
    
    
    
            int index = 0;
            Point primaryMonitorPoint = new Point(0, 0);
            List<string> screenos = new List<string>();
            Dictionary<string, Image> images = new Dictionary<string, Image>();
            public void Main(string file)
            {
                images[screenos[index]] = Image.FromFile(file);
                if (index == screenos.Count - 1)
                    index = 0;
                else
                    index++;
    
                //figure our where the main monitor is in relation to the virtualScreenBitmap
                foreach (Screen scr in System.Windows.Forms.Screen.AllScreens)
                {
                    if (scr.Bounds.Left < primaryMonitorPoint.X)
                        primaryMonitorPoint.X = scr.Bounds.Left;
                    if (scr.Bounds.Top < primaryMonitorPoint.Y)
                        primaryMonitorPoint.Y = scr.Bounds.Top;
                }
                primaryMonitorPoint.X *= -1;
                primaryMonitorPoint.Y *= -1;
    
                CreateBackgroundImage(images);
                GC.Collect();
    
            }
    
            private void CreateBackgroundImage(Dictionary<string, Image> imageFiles)
            {
                const string defaultBackgroundFile = @"C:\Users\Public\Pictures\Sample Pictures\DefaultBackground.bmp";
    
                using (var virtualScreenBitmap = new Bitmap((int)System.Windows.Forms.SystemInformation.VirtualScreen.Width, (int)System.Windows.Forms.SystemInformation.VirtualScreen.Height))
                {
                    using (var virtualScreenGraphic = Graphics.FromImage(virtualScreenBitmap))
                    {
                        foreach (var screen in System.Windows.Forms.Screen.AllScreens)
                        {
                            var image = (imageFiles.ContainsKey(screen.DeviceName)) ? imageFiles[screen.DeviceName] : null;
    
                            var monitorDimensions = screen.Bounds;
                            var monitorBitmap = new Bitmap(monitorDimensions.Width, monitorDimensions.Height);
                            var fromImage = Graphics.FromImage(monitorBitmap);
                            fromImage.FillRectangle(SystemBrushes.Desktop, 0, 0, monitorBitmap.Width, monitorBitmap.Height);
    
                            if (image != null)
                                DrawImageCentered(fromImage, image, new Rectangle(0, 0, monitorBitmap.Width, monitorBitmap.Height));
    
                            Rectangle rectangle = rectangle = new Rectangle(primaryMonitorPoint.X + monitorDimensions.Left, primaryMonitorPoint.Y + monitorDimensions.Top, monitorDimensions.Width, monitorDimensions.Height);
    
                            virtualScreenGraphic.DrawImage(monitorBitmap, rectangle);
                        }
                        virtualScreenBitmap.Save(defaultBackgroundFile, ImageFormat.Bmp);
                    }
                }
    
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);
                key.SetValue(@"WallpaperStyle", 0.ToString());
                key.SetValue(@"TileWallpaper", 1.ToString());
                SystemParametersInfo(SetDeskWallpaper, 0, defaultBackgroundFile, UpdateIniFile | SendWinIniChange);
            }
    
    
            private void DrawImageCentered(Graphics g, Image img, Rectangle monitorRect)
            {
                float heightRatio = (float)monitorRect.Height / (float)img.Height;
                float widthRatio = (float)monitorRect.Width / (float)img.Width;
                int height = monitorRect.Height;
                int width = monitorRect.Width;
                int x = 0;
                int y = 0;
    
                if (heightRatio > 1f && widthRatio > 1f)
                {
                    height = img.Height;
                    width = img.Width;
                    x = (int)((float)(monitorRect.Width - width) / 2f);
                    y = (int)((float)(monitorRect.Height - height) / 2f);
                }
                else
                {
                    if (heightRatio < widthRatio)
                    {
                        width = (int)((float)img.Width * heightRatio);
                        height = (int)((float)img.Height * heightRatio);
                        x = (int)((float)(monitorRect.Width - width) / 2f);
                    }
                    else
                    {
                        width = (int)((float)img.Width * widthRatio);
                        height = (int)((float)img.Height * widthRatio);
                        y = (int)((float)(monitorRect.Height - height) / 2f);
                    }
                }
    
                Rectangle rect = new Rectangle(x, y, width, height);
                g.DrawImage(img, rect);
            }
        }
    }

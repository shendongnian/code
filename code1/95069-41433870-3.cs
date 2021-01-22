    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using Microsoft.Win32;
    using System.Windows.Forms;
    using System.IO;
    
    
    namespace toolbox.Wallpaper
    {
        public class CustomWally
        {
            const int SetDeskWallpaper = 20;
            const int UpdateIniFile = 0x01;
            const int SendWinIniChange = 0x02;
            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);
    
    
    
    
            Point primaryMonitorPoint = new Point(0, 0);
            const string defaultBackgroundFile = @"C:\Users\Public\Pictures\Sample Pictures\DefaultBackground.jpg";
            Dictionary<string, Image> images = new Dictionary<string, Image>();
    
            public CustomWally()
            {
                //figure out where the main monitor is in relation to the virtualScreenBitmap
                foreach (Screen scr in Screen.AllScreens)
                {
                    images.Add(scr.DeviceName, null);
                    screenos.Add(scr.DeviceName);
                    if (scr.Bounds.Left < primaryMonitorPoint.X)
                        primaryMonitorPoint.X = scr.Bounds.Left;
                    if (scr.Bounds.Top < primaryMonitorPoint.Y)
                        primaryMonitorPoint.Y = scr.Bounds.Top;
                }
                primaryMonitorPoint.X *= -1;
                primaryMonitorPoint.Y *= -1;
    
                //Image for multiple screens
                images.Add("all", null);
    
                //set Images in Dictionary in case there are previous Images
                if (File.Exists(defaultBackgroundFile))
                {
                    using (var old = new Bitmap(defaultBackgroundFile))
                    {
                        foreach (Screen scr in Screen.AllScreens)
                        {
                            Rectangle rectangle = new Rectangle(primaryMonitorPoint.X + scr.Bounds.Left, primaryMonitorPoint.Y + scr.Bounds.Top, scr.Bounds.Width, scr.Bounds.Height);
                            if (old.Width >= (rectangle.X + rectangle.Width) &&
                                old.Height >= (rectangle.Y + rectangle.Height))
                                images[scr.DeviceName] = (Bitmap)old.Clone(rectangle, old.PixelFormat);
                        }
                    }
                }
            }
    
    
    
            List<string> screenos = new List<string>();
            int index = 0;
    
    
            public void setAlternatingWalls(string file)
            {
                images[screenos[index]] = Image.FromFile(file);
                index++;
                if (index == screenos.Count)
                    index = 0;
    
                CreateBackgroundImage(Method.multiple);
                GC.Collect();
            }
    
            public void setWallforScreen(Screen screen, string file)
            {
                images[screen.DeviceName] = Image.FromFile(file);
                CreateBackgroundImage(Method.multiple);
                GC.Collect();
            }
    
            public void setWallforAllScreen(string file)
            {
                images["all"] = Image.FromFile(file);
                CreateBackgroundImage(Method.single);
                GC.Collect();
            }
    
    
            private enum Method
            {
                multiple,
                single
            }
            private void CreateBackgroundImage(Method method)
            {
    
                using (var virtualScreenBitmap = new Bitmap((int)System.Windows.Forms.SystemInformation.VirtualScreen.Width, (int)System.Windows.Forms.SystemInformation.VirtualScreen.Height))
                {
                    using (var virtualScreenGraphic = Graphics.FromImage(virtualScreenBitmap))
                    {
    
                        switch (method)
                        {
                            // alternated Screen Images
                            case Method.multiple:
                                foreach (var screen in System.Windows.Forms.Screen.AllScreens)
                                {
                                    // gets the image which we want to place in virtualScreenGraphic
                                    var image = (images.ContainsKey(screen.DeviceName)) ? images[screen.DeviceName] : null;
    
                                    //sets the position and size where the images will go
                                    Rectangle rectangle = new Rectangle(primaryMonitorPoint.X + screen.Bounds.Left, primaryMonitorPoint.Y + screen.Bounds.Top, screen.Bounds.Width, screen.Bounds.Height);
    
                                    // produce a image for the screen and fill it with the desired image... centered
                                    var monitorBitmap = new Bitmap(rectangle.Width, rectangle.Height);
                                    if (image != null)
                                        DrawImageCentered(Graphics.FromImage(monitorBitmap), image, rectangle);
    
                                    //draws the picture at the right place in virtualScreenGraphic
                                    virtualScreenGraphic.DrawImage(monitorBitmap, rectangle);
                                }
                                break;
    
                            //Single screen Image
                            case Method.single:
                                // gets the image which we want to place in virtualScreenGraphic
                                var image2 = images["all"];
    
                                //sets the position and size where the images will go
                                Rectangle rectangle2 = new Rectangle(0, 0, virtualScreenBitmap.Width, virtualScreenBitmap.Height);
    
                                // fill with the desired image... centered                            
                                if (image2 != null)
                                    DrawImageCentered(virtualScreenGraphic, image2, rectangle2);
    
                                //draws the picture at the right place in virtualScreenGraphic
                                virtualScreenGraphic.DrawImage(virtualScreenBitmap, rectangle2);
                                break;
                        }
    
                        virtualScreenBitmap.Save(defaultBackgroundFile, ImageFormat.Jpeg);
                    }
                }
    
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);
                key.SetValue(@"WallpaperStyle", 0.ToString());
                key.SetValue(@"TileWallpaper", 1.ToString());
                SystemParametersInfo(SetDeskWallpaper, 0, defaultBackgroundFile, UpdateIniFile | SendWinIniChange);
            }
    
    
            private void DrawImageCentered(Graphics g, Image img, Rectangle monitorRect)
            {
                double ratiodev = (1.0 * monitorRect.Width / monitorRect.Height) - (1.0 * img.Width / img.Height);
                if (((1.0 * monitorRect.Width / monitorRect.Height > 1) && ratiodev > -0.25 && ratiodev < 0.25))
                {
                    img = getsnappedIMG(img, monitorRect);
                }
    
    
                float heightRatio = (float)monitorRect.Height / (float)img.Height;
                float widthRatio = (float)monitorRect.Width / (float)img.Width;
                int height = monitorRect.Height;
                int width = monitorRect.Width;
                int x = 0;
                int y = 0;
    
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
                Rectangle rect = new Rectangle(x, y, width, height);
                g.DrawImage(img, rect);
            }
    
            private Image getsnappedIMG(Image img, Rectangle monitorRect)
            {
                double ratiodev = (1.0 * monitorRect.Width / monitorRect.Height) - (1.0 * img.Width / img.Height);
                int height = img.Height;
                int width = img.Width;
    
                Rectangle rect;
                if (ratiodev < 0)
                {
                    rect = new Rectangle(0, 0, (int)((1.0 * monitorRect.Width / monitorRect.Height) * height), height);                
                    rect.X = (width - rect.Width) / 2;                
                }
                else
                {
                    rect = new Rectangle(0, 0, width, (int)(1.0 * width / (1.0 * monitorRect.Width / monitorRect.Height)));
                    rect.Y = (height - rect.Height) / 2;
                }
    
                
                var img2 = (Bitmap)img;
                return (Bitmap)img2.Clone(rect, img.PixelFormat);
    
            }
        }
    }

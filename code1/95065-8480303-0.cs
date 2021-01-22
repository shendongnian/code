    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Runtime.InteropServices;
    
    namespace SetWallpapers
    {
        internal class Program
        {
            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            private static extern Int32 SystemParametersInfo(UInt32 uiAction, UInt32 uiParam, String pvParam, UInt32 fWinIni);
    
            private static UInt32 SPI_SETDESKWALLPAPER = 20;
            private static UInt32 SPIF_UPDATEINIFILE = 0x1;
    
            public void SetImage(string filename)
            {
                SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, filename, SPIF_UPDATEINIFILE);
            }
    
            private static void Main(string[] args)
            {
                var images = new Dictionary<string, Image>
                {
                    { @"\\.\DISPLAY1", Image.FromFile(@"C:\Users\Public\Pictures\Sample Pictures\Lighthouse.jpg") },
                    { @"\\.\DISPLAY2", Image.FromFile(@"C:\Users\Public\Pictures\Sample Pictures\Jellyfish.jpg") },
                    { @"\\.\DISPLAY3", Image.FromFile(@"C:\Users\Public\Pictures\Sample Pictures\Koala.jpg") }
                };
    
                CreateBackgroundImage(images);
    
            }
    
            private static void CreateBackgroundImage(Dictionary<string, Image> imageFiles)
            {
                const string defaultBackgroundFile = @"C:\Users\Public\Pictures\Sample Pictures\DefaultBackground.bmp";
    
                using (var virtualScreenBitmap = new Bitmap((int)System.Windows.SystemParameters.VirtualScreenWidth, (int)System.Windows.SystemParameters.VirtualScreenHeight))
                {
                    using (var virtualScreenGraphic = Graphics.FromImage(virtualScreenBitmap))
                    {
                        foreach (var screen in System.Windows.Forms.Screen.AllScreens)
                        {
                            var image = (imageFiles.ContainsKey(screen.DeviceName)) ? imageFiles[screen.DeviceName] : null;
    
                            var monitorDimensions = screen.Bounds;
                            var width = monitorDimensions.Width;
                            var monitorBitmap = new Bitmap(width, monitorDimensions.Height);
                            var fromImage = Graphics.FromImage(monitorBitmap);
                            fromImage.FillRectangle(SystemBrushes.Desktop, 0, 0, monitorBitmap.Width, monitorBitmap.Height);
    
                            if (image != null)
                                DrawImageCentered(fromImage, image, new Rectangle(0, 0, monitorBitmap.Width, monitorBitmap.Height));
    
                            Rectangle rectangle;
                            if (monitorDimensions.Top == 0 && monitorDimensions.Left == 0)
                            {
                                rectangle = monitorDimensions;
                            }
                            else
                            {
                                if ((monitorDimensions.Left < 0 && monitorDimensions.Width > -monitorDimensions.Left) ||
                                    (monitorDimensions.Top < 0 && monitorDimensions.Height > -monitorDimensions.Top))
                                {
                                    var isMain = (monitorDimensions.Top < 0 && monitorDimensions.Bottom > 0);
    
                                    var left = (monitorDimensions.Left < 0)
                                                   ? (int) System.Windows.SystemParameters.VirtualScreenWidth + monitorDimensions.Left
                                                   : monitorDimensions.Left;
    
                                    var top = (monitorDimensions.Top < 0)
                                                  ? (int) System.Windows.SystemParameters.VirtualScreenHeight + monitorDimensions.Top
                                                  : monitorDimensions.Top;
    
                                    Rectangle srcRect;
                                    if (isMain)
                                    {
                                        rectangle = new Rectangle(left, 0, monitorDimensions.Width, monitorDimensions.Bottom);
                                        srcRect = new Rectangle(0, -monitorDimensions.Top, monitorDimensions.Width, monitorDimensions.Height + monitorDimensions.Top);
                                    }
                                    else
                                    {
                                        rectangle = new Rectangle(0, top, monitorDimensions.Right, monitorDimensions.Height);
                                        srcRect = new Rectangle(-monitorDimensions.Left, 0, monitorDimensions.Width + monitorDimensions.Left,
                                                                monitorDimensions.Height);
                                    }
    
                                    virtualScreenGraphic.DrawImage(monitorBitmap, rectangle, srcRect, GraphicsUnit.Pixel);
                                    rectangle = new Rectangle(left, top, monitorDimensions.Width, monitorDimensions.Height);
                                }
                                else
                                {
                                    var left = (monitorDimensions.Left < 0)
                                                   ? (int) System.Windows.SystemParameters.VirtualScreenWidth + monitorDimensions.Left
                                                   : monitorDimensions.Left;
                                    var top = (monitorDimensions.Top < 0)
                                                  ? (int) System.Windows.SystemParameters.VirtualScreenHeight + monitorDimensions.Top
                                                  : monitorDimensions.Top;
                                    rectangle = new Rectangle(left, top, monitorDimensions.Width, monitorDimensions.Height);
                                }
                            }
                            virtualScreenGraphic.DrawImage(monitorBitmap, rectangle);
                        }
    
                        virtualScreenBitmap.Save(defaultBackgroundFile, ImageFormat.Bmp);
                    }
                }
    
                SystemParametersInfo(SPI_SETDESKWALLPAPER, 0u, defaultBackgroundFile, SPIF_UPDATEINIFILE);
            }
    
    
            private static void DrawImageCentered(Graphics g, Image img, Rectangle monitorRect)
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

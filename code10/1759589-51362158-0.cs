     public class ImageHelper
        {
            public static byte[] CropImage(byte[] sourceImage, Color grey)
            {
                using (var ms = new MemoryStream(sourceImage))
                {
                    var Img = new Bitmap(ms);
    
                    using (Bitmap bmp = new Bitmap(Img))
                    {
                        var midX = bmp.Width / 2;
                        var midY = bmp.Height / 2;
                        var yTop = 0;
                        var yBottom = bmp.Height;
                        var xLeft = 0;
                        var xRight = bmp.Width;
    
                        for (int y = 0; y < bmp.Height; y++)
                        {
                            Color pxl = bmp.GetPixel(midX, y);
                            if (pxl != grey)
                            {
                                yTop = y;
                                break;
                            }
                        }
    
                        for (int x = 0; x < bmp.Width; x++)
                        {
                            Color pxl = bmp.GetPixel(x, midX);
                            if (pxl != grey)
                            {
                                xLeft = x;
                                break;
                            }
                        }
    
                        for (int x = bmp.Width - 1; x > midX; x--)
                        {
                            Color pxl = bmp.GetPixel(x, midX);
                            if (pxl != grey)
                            {
                                xRight = x;
                                break;
                            }
                        }
    
                        for (int y = bmp.Height - 1; y > midY; y--)
                        {
                            Color pxl = bmp.GetPixel(midX, y);
                            if (pxl != grey)
                            {
                                yBottom = y;
                                break;
                            }
                        }
                        Image redBmp = bmp.Clone(new Rectangle(xLeft, yTop, xRight - xLeft, yBottom - yTop), System.Drawing.Imaging.PixelFormat.DontCare);
                        byte[] byteImage = ImageToByteArray(redBmp);
                        return byteImage;
                    }
                }
            }
            public static byte[] ImageToByteArray(Image imageIn)
            {
                MemoryStream ms = new MemoryStream();
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }
    }

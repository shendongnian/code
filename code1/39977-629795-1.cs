            byte[] getResizedImage(String path, int width, int height)
            {
                try
                {
                    Bitmap imgIn = new Bitmap(path);
    
                    //Scale
                    double y = imgIn.Height;
                    double x = imgIn.Width;
                    double factor = 1;
                    if (width > 0)
                    {
                        factor = width / x;
                    }
                    else if (height > 0)
                    {
                        factor = height / y;
                    }
    
                    System.IO.MemoryStream outStream = new System.IO.MemoryStream();
                    Bitmap imgOut = new Bitmap((int)(x * factor), (int)(y * factor));
                    Graphics g = Graphics.FromImage(imgOut);
                    g.Clear(Color.White);
                    g.DrawImage(imgIn, new Rectangle(0, 0, (int)(factor * x), (int)(factor * y)), new Rectangle(0, 0, (int)x, (int)y), GraphicsUnit.Pixel);
                    imgOut.Save(outStream, ImageFormat.Jpeg);
    
                    return outStream.ToArray();
    
                }
                catch (Exception)
                {
    ...
                }
                
            }

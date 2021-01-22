    //Example : 
         System.Net.Mime.MediaTypeNames.Image newImage = System.Net.Mime.MediaTypeNames.Image.FromFile("SampImag.jpg");
            System.Net.Mime.MediaTypeNames.Image temImag = FormatImage(newImage, 100, 100);
    
    //image size modification unction   
            public static System.Net.Mime.MediaTypeNames.Image FormatImage(System.Net.Mime.MediaTypeNames.Image img, int outputWidth, int outputHeight)
                        {
                
                            Bitmap outputImage = null;
                            Graphics graphics = null;
                            try
                            {
                                outputImage = new Bitmap(outputWidth, outputHeight, System.Drawing.Imaging.PixelFormat.Format16bppRgb555);
                                graphics = Graphics.FromImage(outputImage);
                                graphics.DrawImage(img, new Rectangle(0, 0, outputWidth, outputHeight),
                                new Rectangle(0, 0, img.Width, img.Height), GraphicsUnit.Pixel);
                
                                return outputImage;
                            }
                            catch (Exception ex)
                            {
                                return img;
                            }
                        }

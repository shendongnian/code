        private static void ConvertTo24(string inputFileName, string outputFileName)
        {
            Bitmap bmpIn = (Bitmap)Bitmap.FromFile(inputFileName);
            Bitmap converted = new Bitmap(bmpIn.Width, bmpIn.Height, PixelFormat.Format24bppRgb);
            using (Graphics g = Graphics.FromImage(converted))
            {
                g.DrawImageUnscaled(bmpIn, 0, 0);
            }
            converted.Save(outputFileName, ImageFormat.Bmp);
        }

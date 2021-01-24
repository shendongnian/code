        public void ExampleMethod()
        {
            pictureBox1.Image = GetCompressedFile("file.jpg", quality: 10);
        }
        private Image GetCompressedFile(string fileName, long quality)
        {
            using (Bitmap bitmap = new Bitmap(fileName))
            {
                return GetCompressedBitmap(bitmap, quality);
            }
        }
        private Image GetCompressedBitmap(Bitmap bmp, long quality)
        {
            using (var mss = new MemoryStream())
            {
                EncoderParameter qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
                ImageCodecInfo imageCodec = ImageCodecInfo.GetImageEncoders().FirstOrDefault(o => o.FormatID == ImageFormat.Jpeg.Guid);
                EncoderParameters parameters = new EncoderParameters(1);
                parameters.Param[0] = qualityParam;
                bmp.Save(mss, imageCodec, parameters);
                return Image.FromStream(mss);
            }
        }

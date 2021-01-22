     public static void ResizeJpg(string path, int nWidth, int nHeight)
        {
            using (var result = new Bitmap(nWidth, nHeight))
            {
                using (var input = new Bitmap(path))
                {
                    using (Graphics g = Graphics.FromImage((System.Drawing.Image)result))
                    {
                        g.DrawImage(input, 0, 0, nWidth, nHeight);
                    }
                }
                var ici = ImageCodecInfo.GetImageEncoders().FirstOrDefault(ie => ie.MimeType == "image/jpeg");
                var eps = new EncoderParameters(1);
                eps.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);
                result.Save(path, ici, eps);
            }
        }

     public static Stream GetPNGBitmapStream(Image initial)
        {
            return GetBitmapStream(initial, "image/PNG");
        }
        public static Stream GetJPGBitmapStream(Image initial)
        {
            return GetBitmapStream(initial, "image/jpeg");
        }
        private static Stream GetBitmapStream(Image initial, string mimeType)
        {
            MemoryStream ms = new MemoryStream();
            var qualityEncoder = Encoder.Quality;
            var quality = (long)90;
            var ratio = new EncoderParameter(qualityEncoder, quality);
            var codecParams = new EncoderParameters(1);
            codecParams.Param[0] = ratio;
            ImageCodecInfo[] infos = ImageCodecInfo.GetImageEncoders();
            ImageCodecInfo jpegCodecInfo = null;
            for (int i = 0; i < infos.Length; i++)
            {
                if (string.Compare(infos[i].MimeType, mimeType,true) == 0)
                {
                    jpegCodecInfo = infos[i];
                    break;
                }
            }
            if (jpegCodecInfo != null)
            {
                initial.Save(ms, jpegCodecInfo, codecParams); 
                MemoryStream ms2 = new MemoryStream(ms.ToArray());
                ms.Close();
                ms.Dispose();
                return ms2;
            }
            return null;
        }

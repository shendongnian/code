            public void toCCITT(string tifURL)
        {
            byte[] imgBits = File.ReadAllBytes(tifURL);
            using (MemoryStream ms = new MemoryStream(imgBits))
            {
                using (Image i = Image.FromStream(ms))
                {
                    EncoderParameters parms = new EncoderParameters(1);
                    ImageCodecInfo codec = ImageCodecInfo.GetImageDecoders()
                                                         .FirstOrDefault(decoder => decoder.FormatID == ImageFormat.Tiff.Guid);
                    parms.Param[0] = new EncoderParameter(Encoder.Compression, (long)EncoderValue.CompressionCCITT4);
                    
                    i.Save(@"c:\test\result.tif", codec, parms);
                }
            }
        }

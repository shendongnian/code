    public class MultiPageTiff
    {
        private static System.Drawing.Imaging.ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            System.Drawing.Imaging.ImageCodecInfo[] encoders =
                System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders();
            if (encoders != null)
            {
                for (int i = 0; i < encoders.Length; i++)
                {
                    if (encoders[i].MimeType == mimeType)
                    {
                        return encoders[i];
                    } // End if (encoders[i].MimeType == mimeType) 
                } // Next i 
            } // End if (encoders != null) 
            return null;
        } // End Function GetEncoderInfo 
        public static System.Drawing.Image Generate(string[] filez)
        {
            System.Drawing.Image multiPageFile = null;
            byte[] ba = null;
            System.Drawing.Imaging.ImageCodecInfo tiffCodec = GetEncoderInfo("image/tiff");
            
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                for (int i = 0; i < filez.Length; ++i)
                {
                    using (System.Drawing.Image inputImage = System.Drawing.Image.FromFile(filez[i]))
                    {
                        using (System.IO.MemoryStream byteStream = new System.IO.MemoryStream())
                        {
                            inputImage.Save(byteStream, System.Drawing.Imaging.ImageFormat.Tiff);
                            if (i == 0)
                            {
                                multiPageFile = System.Drawing.Image.FromStream(byteStream);
                                multiPageFile = SaveImages(tiffCodec, ms, multiPageFile, null);
                            }
                            else
                            {
                                using (System.Drawing.Image tiffImage = System.Drawing.Image.FromStream(byteStream))
                                {
                                    multiPageFile = SaveImages(tiffCodec, ms, tiffImage, multiPageFile);
                                } // End Using tiffImage 
                            }
                        } // End Using byteStream 
                    } // End Using inputImage 
                } // Next i 
                ba = ms.ToArray();
            } // End Using ms 
            System.IO.File.WriteAllBytes(@"d:\mytiff.tiff", ba);
            //if (multiPageFile != null)
            //{
            //    multiPageFile.Dispose();
            //    multiPageFile = null;
            //}
            return multiPageFile;
        }
        private static System.Drawing.Image SaveImages(
              System.Drawing.Imaging.ImageCodecInfo tiffCodec
            , System.IO.MemoryStream outputStream
            , System.Drawing.Image tiffImage, System.Drawing.Image firstImage)
        {
            using (System.Drawing.Imaging.EncoderParameters encParameters =
                  new System.Drawing.Imaging.EncoderParameters(3))
            {
                if (firstImage == null)
                {
                    encParameters.Param[0] = new System.Drawing.Imaging.EncoderParameter(
                        System.Drawing.Imaging.Encoder.SaveFlag
                        , (long)System.Drawing.Imaging.EncoderValue.MultiFrame // 18L 
                    );
                }
                else
                {
                    encParameters.Param[0] = new System.Drawing.Imaging.EncoderParameter(
                        System.Drawing.Imaging.Encoder.SaveFlag
                        , (long)System.Drawing.Imaging.EncoderValue.FrameDimensionPage // 23L
                    );
                }
                encParameters.Param[1] = new System.Drawing.Imaging.EncoderParameter(
                    System.Drawing.Imaging.Encoder.ColorDepth, 24L
                );
                encParameters.Param[2] = new System.Drawing.Imaging.EncoderParameter(
                    System.Drawing.Imaging.Encoder.Compression
                    , (long)System.Drawing.Imaging.EncoderValue.CompressionLZW
                );
                if (firstImage == null)
                {
                    firstImage = tiffImage;
                    ((System.Drawing.Bitmap)tiffImage).SetResolution(96, 96);
                    firstImage.Save(outputStream, tiffCodec, encParameters);
                }
                else
                {
                    ((System.Drawing.Bitmap)tiffImage).SetResolution(96, 96);
                    firstImage.SaveAdd(tiffImage, encParameters);
                }
                if (encParameters.Param[0] != null)
                    encParameters.Param[0].Dispose();
                if (encParameters.Param[1] != null)
                    encParameters.Param[1].Dispose();
                if (encParameters.Param[2] != null)
                    encParameters.Param[2].Dispose();
                
            } // End Using encParameters 
            return firstImage;
        }
    }

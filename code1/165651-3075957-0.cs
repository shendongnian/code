        private void MakeResizedImage(string fromFile, string toFile, int maxWidth, int maxHeight)
        {
            int width;
            int height;
            using (System.Drawing.Image image = System.Drawing.Image.FromFile(fromFile))
            {
                DetermineResizeRatio(maxWidth, maxHeight, image.Width, image.Height, out width, out height);
                using (System.Drawing.Image thumbnailImage = image.GetThumbnailImage(width, height, new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback), IntPtr.Zero))
                {
                    if (image.Width < thumbnailImage.Width && image.Height < thumbnailImage.Height)
                        File.Copy(fromFile, toFile);
                    else
                    {
                        ImageCodecInfo ec = GetCodecInfo();
                        EncoderParameters parms = new EncoderParameters(1);
                        parms.Param[0] = new EncoderParameter(Encoder.Compression, 40);
                        ZRLabs.Yael.BasicFilters.ResizeFilter rf = new ZRLabs.Yael.BasicFilters.ResizeFilter();
                        //rf.KeepAspectRatio = true;
                        rf.Height = height;
                        rf.Width = width;
                        System.Drawing.Image img = rf.ExecuteFilter(System.Drawing.Image.FromFile(fromFile));
                        img.Save(toFile, ec, parms);
                    }
                }
            }
        }

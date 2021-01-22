        public void SaveFrame(string path, int frameIndex, string toPath)
        {
            using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                BitmapDecoder dec = BitmapDecoder.Create(stream, BitmapCreateOptions.IgnoreImageCache, BitmapCacheOption.None);
                BitmapEncoder enc = BitmapEncoder.Create(dec.CodecInfo.ContainerFormat);
                enc.Frames.Add(dec.Frames[frameIndex]);
                using (FileStream tmpStream = new FileStream(toPath, FileMode.Create))
                {
                    enc.Save(tmpStream);
                }
            }
        }

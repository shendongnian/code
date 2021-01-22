     public string ResizeImageAndSave(int Width, int Height, string imageUrl, string destPath)
        {
            System.Drawing.Image fullSizeImg = System.Drawing.Image.FromFile(imageUrl);
            double widthRatio = (double)fullSizeImg.Width / (double)Width;
            double heightRatio = (double)fullSizeImg.Height / (double)Height;
            double ratio = Math.Max(widthRatio, heightRatio);
            int newWidth = (int)(fullSizeImg.Width / ratio);
            int newHeight = (int)(fullSizeImg.Height / ratio);
            //System.Drawing.Image.GetThumbnailImageAbort dummyCallBack = new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);
            System.Drawing.Image thumbNailImg = fullSizeImg.GetThumbnailImage(newWidth, newHeight, new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback), IntPtr.Zero);
            //DateTime MyDate = DateTime.Now;
            //String MyString = MyDate.ToString("ddMMyyhhmmss") + imageUrl.Substring(imageUrl.LastIndexOf("."));
            thumbNailImg.Save(destPath, ImageFormat.Jpeg);
            thumbNailImg.Dispose();
            return "";
        }
        public bool ThumbnailCallback() { return false; }

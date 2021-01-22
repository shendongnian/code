    // uses System.Drawing namespace
    public class ImageResizer
    {
        public bool ResizeImage(string fullFileName, int maxHeight, int maxWidth)
        {
            return this.ResizeImage(fullFileName, maxHeight, maxWidth, fullFileName);
        }
        public bool ResizeImage(string fullFileName, int maxHeight, int maxWidth, string newFileName)
        {
            using (Image originalImage = Image.FromFile(fullFileName))
            {
                int height = originalImage.Height;
                int width = originalImage.Width;
                int newHeight = maxHeight;
                int newWidth = maxWidth;
                if (height > maxHeight || width > maxWidth)
                {
                    if (height > maxHeight)
                    {
                        newHeight = maxHeight;
                        float temp = ((float)width / (float)height) * (float)maxHeight;
                        newWidth = Convert.ToInt32(temp);
                        height = newHeight;
                        width = newWidth;
                    }
                    if (width > maxWidth)
                    {
                        newWidth = maxWidth;
                        float temp = ((float)height / (float)width) * (float)maxWidth;
                        newHeight = Convert.ToInt32(temp);
                    }
                    Image.GetThumbnailImageAbort abort = new Image.GetThumbnailImageAbort(ThumbnailCallback);
                    using (Image resizedImage = originalImage.GetThumbnailImage(newWidth, newHeight, abort, System.IntPtr.Zero))
                    {
                        resizedImage.Save(newFileName);
                    }
                    return true;
                }
                else if (fullFileName != newFileName)
                {
                    // no resizing necessary, but need to create new file 
                    originalImage.Save(newFileName);
                }
            }
            return false;
        }
        private bool ThumbnailCallback()
        {
            return false;
        }
    }

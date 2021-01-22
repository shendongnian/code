    public class Picture:BaseFile
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public Image Thumbnail { get; set; }
        /// <summary>
        /// Sets file information of an image from a given image in the file path.
        /// </summary>
        /// <param name="filePath">File path of the image.</param>
        public override void  getFileInformation(string filePath)
        {
            FileInfo fileInformation = new FileInfo(filePath);
            if (fileInformation.Exists)
            {
                /*
                Name, FileType, Size, etc
                */
                using (Image image = Image.FromFile(filePath))
                {
                    Height = image.Height;
                    Width = image.Width;
                    Thumbnail = image.GetThumbnailImage(40, 40, new Image.GetThumbnailImageAbort(ThumbnailCallback), default(IntPtr));
                }
            }
        }
        public bool ThumbnailCallback()
        {
            return false;
        }
    }

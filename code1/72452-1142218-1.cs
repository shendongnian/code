    public static class ImageListWrapper
    {
        static ImageListWrapper()
        {
            ImageList = new ImageList();
            LoadImages(ImageList);
        }
    
        private static void LoadImages(ImageList imageList)
        {
            // load images into the list
        }
    
        public static ImageList ImageList { get; private set; }
    }

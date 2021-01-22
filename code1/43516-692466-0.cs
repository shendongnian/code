    public class ImageLoader
    {
        string mediaid;
        BitmapImage thumbnail;
        public string MediaId
        {
            get { return mediaid; }
            set { mediaid = value; }
        }
        public BitmapImage Thumbnail
        { 
            get { return thumbnail; } 
            set { thumbnail = value; } 
        }
        public ImageLoader(string mediaid, BitmapImage b)
        {
            this.mediaid = mediaid;
            this.thumbnail = b;
        }
    }

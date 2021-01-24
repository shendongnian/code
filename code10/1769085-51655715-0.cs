    public class SearchResult : INotifyPropertyChanged
    {
        private Uri previewImageUrl;
        public Uri PreviewImageUrl
        {
            get { return previewImageUrl; }
            set
            {
                previewImageUrl = value;
                previewImage = null;
                NotifyPropertyChanged(nameof(PreviewImageUrl));
                NotifyPropertyChanged(nameof(PreviewImage));
            }
        }
        private ImageSource previewImage;
        public ImageSource PreviewImage
        {
            get
            {
                if (previewImage == null && previewImageUrl != null)
                {
                    previewImage = new BitmapImage(previewImageUrl);
                }
                return previewImage;
            }
        }
        ...
    }

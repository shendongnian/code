    public class ViewModel : ViewModelBase
    {
        private string imagePath;
        private BitmapImage image;
        public string ImagePath
        {
            get { return imagePath; }
            set
            {
                imagePath = value;
                image = null;
                OnPropertyChanged(nameof(ImagePath));
                OnPropertyChanged(nameof(Image));
            }
        }
        public BitmapImage Image
        {
            get
            {
                lock (this)
                {
                    if (image == null &&
                        !string.IsNullOrEmpty(imagePath) &&
                        File.Exists(imagePath))
                    {
                        using (var stream = File.OpenRead(imagePath))
                        {
                            image = new BitmapImage();
                            image.BeginInit();
                            image.CacheOption = BitmapCacheOption.OnLoad;
                            image.DecodePixelWidth = 200;
                            image.StreamSource = stream;
                            image.EndInit();
                            image.Freeze();
                        }
                    }
                }
                return image;
            }
        }
    }

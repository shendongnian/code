    private Image image;
        public Page()
        {
            InitializeComponent();
            LoadImage("image.png");
        }
        private void LoadImage(string path)
        {
            Uri uri = new Uri(path, UriKind.Relative);
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.UriSource = uri;
            bitmapImage.DownloadProgress += 
                new EventHandler<DownloadProgressEventArgs>(bitmapImage_DownloadProgress);
        }
        void bitmapImage_DownloadProgress(object sender, DownloadProgressEventArgs e)
        {
            if (e.Progress == 100)
            {
                Dispatcher.BeginInvoke(delegate()
                {
                   double height = image.ActualHeight;
                   double width = image.ActualWidth;
                });
            }
        }

    class ViewModel
    {
        private ImageSource imageSource;
        public ViewModel()
        {
            ...
            if (openPicture.ShowDialog() == true) 
            {
                var filepath = openPicture.FileName;
                imageSource = Model.Init(new Bitmap(filepath));
            }
        }
        public ImageSource DisplayedImage
        {
            get { return imageSource; }
        }
    }

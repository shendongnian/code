    class ViewModel
    {
        private ImageSource imageSource;
        public ViewModel()
        {
            OpenFileDialog openPicture = new OpenFileDialog();
            openPicture.Filter = "Image files|*.bmp;*.jpg;*.gif;*.png;*.tif|All files|*.*";
            openPicture.FilterIndex = 1;
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

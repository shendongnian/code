    class ViewModel
    {
        public ViewModel()
        {
            ...
            if (openPicture.ShowDialog() == true) 
            {
                DisplayedImage = Model.Init(new Bitmap(openPicture.FileName));
            }
        }
        public ImageSource DisplayedImage { get; private set; }
    }

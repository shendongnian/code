     private string _imgContent= "ms-appx:///Assets/Image.png";
     public string ImageUri
     {
         get { return _imgContent; }
         set
         {
             _imgContent = value;
             OnPropertyChanged(nameof(ImageUri));
         }
     }

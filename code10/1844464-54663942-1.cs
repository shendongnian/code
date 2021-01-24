    public object GetImageOverlay()
    { 
      var imageView = new UIImageView(UIImage.FromBundle("yourimagename.png"));
      imageView.ContentMode = UIViewContentMode.ScaleAspectFit;
      var screen = UIScreen.MainScreen.Bounds;
      imageView.Frame = screen;
      return imageView;               
    }

    // Create an Image element.
    Image croppedImage = new Image();
    croppedImage.Width = 200;
    croppedImage.Margin = new Thickness(5);
    
    // Create a CroppedBitmap based off of a xaml defined resource.
    CroppedBitmap cb = new CroppedBitmap(     
       (BitmapSource)this.Resources["masterImage"],
       new Int32Rect(30, 20, 105, 50));       //select region rect
    croppedImage.Source = cb;                 //set image source to cropped

public string ImageUri {
    set {
        myImage.Source = new BitmapImage(value);
    }
}
Then your calling code can just call myButton.ImageUri = *where my Uri is*

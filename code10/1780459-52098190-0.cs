    public string ImageSource1 => Windows.Storage.ApplicationData.Current.LocalFolder + "/Image_1.png";
    public string ImageSource2 => Windows.Storage.ApplicationData.Current.LocalFolder + "/Image_2.png";
    
    // invoke the NotifyPropertyChanged event to enforce an update.
    public void UpdateImages()  {
        InvokePropertyChanged(nameof(ImageSource1));
        InvokePropertyChanged(nameof(ImageSource2));
    }

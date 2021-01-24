    public void SetImages()
    {
        StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
        Image_1.Source= new BitmapImage(new Uri(localFolder.Path + "/Image_1.png"));
        Image_2.Source= new BitmapImage(new Uri(localFolder.Path + "/Image_2.png"));
        Image_3.Source= new BitmapImage(new Uri(localFolder.Path + "/Image_3.png"));
    }

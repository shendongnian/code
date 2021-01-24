    private bool? isDownloading;
    
    public bool? IsDownloading
     {
        get { return isDownloading; }
        set
        {
           isDownloading = value;
           OnPropertyChanged("IsDownloading");
        }
     }

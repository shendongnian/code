    private ObservableCollection<ImageProperties> imagePropertiesList;
    public ObservableCollection<ImageProperties> ImagePropertiesList
    {
        get
        {
            if(imagePropertiesList == null)            
                imagePropertiesList = new ObservableCollection<ImageProperties>();           
            return imagePropertiesList;
        }
        set
        {
            if(imagePropertiesList != value)
            {
                imagePropertiesList = value;
                OnPropertyChanged();
            }
        }
    }

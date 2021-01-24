    public IMiCasaViewModel ViewModel 
    { 
        get
        {
            return (INormalizationViewModel)DataContext;
        }
        set
        {
            DataContext = value;
        }
    }

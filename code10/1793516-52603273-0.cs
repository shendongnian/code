    int _ipp
    public int ipp
    { 
       get=>_ipp;
       set{
            if (value!=_ipp)
            {
               _ipp=value;
               RaisePropertyChanged(nameof(ipp));
            }
       }
    }
    void RaisePropertyChanged(string propname)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propname));
    }
    
    
    public Window1()
    {
         ipp = 30;
         InitializeComponent();
    }

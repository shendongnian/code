    public int CurrWidth
    {
        get
        {
            return currwidth;
        }
        set
        {
            currwidth = value;
            OnPropertyChanged(new PropertyChangedEventArgs("CurrWidth"));
            OnPropertyChanged(new PropertyChangedEventArgs("ReqWidth"));
            OnPropertyChanged(new PropertyChangedEventArgs("MinGridSize"));
        }
    }
    public int MinGridSize
    {
        get
        {
           return 50 * NbrCol;
        }
    }
    public int ReqWidth
    {
       get
       {
          double width = 0;
          if(NbrCol > 0 && CurrWidth > 0)
          {
             width = CurrWidth / NbrCol;
          }
          else
          {
             width = 50;
          }
          return (int)Math.Round(width, 0);
       }
    }

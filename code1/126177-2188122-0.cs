    private int _date;
    
    public int Date
    {
      get { return _date; }
      set
      {
        if (value != _date)
        {
          _date = value;
          // raise change event here
        }
      }
    }

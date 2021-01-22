    public bool IsEnabled
    {
      get { return isEnabled; }
      set
      {
        if(isEnabled != value)
        {
          isEnabled = value;
          IsEnabledChanged(this,args);
        }
      }
    }

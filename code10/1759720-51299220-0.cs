    public String T1
    {
      set
      {
        t1 = value;
        OnPropertyChanged(nameof(T1));
        Concat = T1 + T2;
      }
    }

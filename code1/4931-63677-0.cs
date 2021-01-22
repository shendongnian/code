    private void SetValue<T>(ref T backingField, T value)
    {
       if (backingField != value)
       {
          backingField = value;
          IsDirty = true;
       }
    }
    public string Name
    {
       get
       {
          return _name;
       }
       set
       {
          SetValue(ref _name, value);
       }
    }

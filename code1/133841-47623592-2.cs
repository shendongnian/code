    class Entity : IChangeTracking
    {
      string _FirstName;
      public string FirstName
      {
        get => _FirstName;
        set
        {
          if (_FirstName != value)
          {
            _FirstName = value;
            IsChanged = true;
          }
        }
      }
      string _LastName;
      public string LastName
      {
        get => _LastName;
        set
        {
          if (_LastName != value)
          {
            _LastName = value;
            IsChanged = true;
          }
        }
      }
      public bool IsChanged { get; private set; }    
      public void AcceptChanges() => IsChanged = false;
    }

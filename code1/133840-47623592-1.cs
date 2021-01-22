    class Entity : IRevertibleChangeTracking
    {
      Dictionary<string, object> _Values = new Dictionary<string, object>();
      string _FirstName;
      public string FirstName
      {
        get => _FirstName;
        set
        {
          if (_FirstName != value)
          {
            if (!_Values.ContainsKey(nameof(FirstName)))
              _Values[nameof(FirstName)] = _FirstName;
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
            if (!_Values.ContainsKey(nameof(LastName)))
              _Values[nameof(LastName)] = _LastName;
            _LastName = value;
            IsChanged = true;
          }
        }
      }
      public bool IsChanged { get; private set; }
      public void RejectChanges()
      {
        foreach (var property in _Values)
          GetType().GetRuntimeProperty(property.Key).SetValue(this, property.Value);
        AcceptChanges();
      }
      public void AcceptChanges()
      {
        _Values.Clear();
        IsChanged = false;
      }
    }

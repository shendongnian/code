    public InternalControl InternalControl
    {
      get { return _internalControl; }
      set
      {
        var enumerator = value.GetLocalValueEnumerator();
        while(enumerator.MoveNext())
        {
          var entry = enumerator.Current as LocalValueEntry;
          _internalControl.SetValue(entry.Property, entry.Value);
        }
      }
    }

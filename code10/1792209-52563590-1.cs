    protected void Set<T>(ref T storage, T value, blah blah blah)
    {
        if (Equals(storage, value))
            return;
        if (storage is double && value is double) 
        {
          double oldValue = (double)(object)storage;
          double newValue = (double)(object)value;
          if (Negligible(...

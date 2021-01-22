    PropertyChanged(this, new PropertyChangedEventArgs(propertyName))
    if (_DependencyMap.ContainsKey(propertyName))
    {
       foreach (string p in _DependencyMap[propertyName])
       {
          PropertyChanged(this, new PropertyChangedEventArgs(p))
       }
    }

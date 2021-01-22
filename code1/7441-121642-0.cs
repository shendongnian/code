    internal struct Pair<T, K> : IEquatable<Pair<T, K>>
    {
      private readonly T _first;
      private readonly K _second;
    
      public Pair(T first, K second)
      {
        _first = first;
        _second = second;
      }
    
      public T First
      {
        get { return _first; }
      }
    
      public K Second
      {
        get { return _second; }
      }
    
      public bool Equals(Pair<T, K> obj)
      {
        return Equals(obj._first, _first) && Equals(obj._second, _second);
      }
    
      public override bool Equals(object obj)
      {
        return obj is Pair<T, K> && Equals((Pair<T, K>) obj);
      }
    
      public override int GetHashCode()
      {
        unchecked
        {
          return (_first != null ? _first.GetHashCode() * 397 : 0) ^ (_second != null ? _second.GetHashCode() : 0);
        }
      }
    }

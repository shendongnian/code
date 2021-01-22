    class A : IEnumerable<B>
    {
      ...
      public IEnumerator<B> GetEnumerator ( )
      {
        return _dictionary.GetEnumerator ( );
      }
      private Dictionary<B> _dictionary;
    }

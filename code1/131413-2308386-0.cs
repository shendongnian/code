    class ResetableEnumerator<T> : IEnumerator<T>
    {
      public IEnumerator<T> Enumerator { get; set; }
      public Func<IEnumerator<T>> ResetFunc { get; set; }
    
      public T Current { get { return Enumerator.Current; } }
      public void  Dispose() { Enumerator.Dispose(); }
      object IEnumerator.Current { get { return Current; } }
      public bool  MoveNext() { return Enumerator.MoveNext(); }
      public void  Reset() { Enumerator = ResetFunc(); }
    }

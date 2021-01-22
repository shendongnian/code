    // Non-generic IEnumerator shown.
    interface IEnumerator
    {
      bool MoveNext();
      object Current { get; }
      void Reset();
    }

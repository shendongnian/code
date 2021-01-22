    class EmptyEnumerator<T> : IEnumerator<T>
    {
       public readonly static EmptyEnumerator<T> value = new EmptyEnumerator<T>();
       public T Current => throw new InvalidOperationException();
       object IEnumerator.Current => throw new InvalidOperationException();
       public void Dispose() { }
       public bool MoveNext() => false;
       public void Reset() { }
    }

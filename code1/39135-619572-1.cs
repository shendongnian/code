    class Test : IEnumerable, IEnumerator
    {
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        public object Current
        {
            get { throw new NotImplementedException(); }
        }
        public bool MoveNext()
        {
            throw new NotImplementedException();
        }
        public void Reset()
        {
            throw new NotImplementedException();
        }
    }

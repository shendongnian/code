    struct TryResult<T>
    {
        public T Result;
        public bool Succeeded;
    }
    TryResult<int> Parse(string intString)
    {
        ...

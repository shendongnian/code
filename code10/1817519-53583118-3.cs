    public IEnumerable<T> Foo()
    {
        if (<check if sequence will be empty>) {
            return null;
        }
        return GetSequence();
    }
    private IEnumerable<T> GetSequence()
    {
        ...
        yield return item;
        ...
    }

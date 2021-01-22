    public IEnumerable<T> GetAllAs(this X x)
    {
        yield return x.A;
        yield return x.B;
        yield return x.C;
        ...
    }
    public IEnumerable<T> GetAllNonNullAs(this X x)
    {
        return x.GetAllAs().Where(y => y != null);
    }

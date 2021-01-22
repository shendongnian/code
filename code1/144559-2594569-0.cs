    [Something(123)]
    public IEnumerable<Foo> GetAllFoos()
    {
        SetupSomething();
        return GetAllFoosInternal();
    }
    private IEnumerable<Foo> GetAllFoosInternal()
    {
        DataReader dr = RunSomething();
        while (dr.Read())
        {
            yield return Factory.Create(dr);
        }
    }

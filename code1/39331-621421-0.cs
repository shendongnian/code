    public List<string> Foo(List<string> list)
    {
        List<string> newList = list.Clone();
        newList.Add("Bar");
        return newList;
    }

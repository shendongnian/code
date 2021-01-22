    public List<string> Foo(List<string> list)
    {
        List<string> newList = (List<string>)list.Clone();
        newList.Add("Bar");
        return newList;
    }

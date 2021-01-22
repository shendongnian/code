    class ListLazy : Lazy<IList<string>>, IList<string>
    {
        // Stuff
    }
    ...
    Lazy<IList<string>> x = new ListLazy();
    IList<string> list = x;

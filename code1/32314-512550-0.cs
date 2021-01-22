    public static TList CreateList<TList,TItem>(int someArg)
        where TList : BaseList<TItem>, new()
        where TItem : baseItem, new()
    {
        TList temp = new TList<T>();
        temp.Add(new TItem());
        temp.Add(new TItem());
        return temp;
    }

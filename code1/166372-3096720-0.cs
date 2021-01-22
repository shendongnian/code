    public static List<TList> Remove<TList, TRemove>(this List<TList> list)
    {
        list.RemoveAll(item => item is TRemove);
        return list;
    }

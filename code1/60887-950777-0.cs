    public bool LocateInAnyList(Object1 obj)
    {
        return SearchList(listTypeB, obj) || SearchList(listTypeC, obj) || SearchList(listTypeD, obj);
    }
    private static bool SearchList<T>(List<T> list, Object1 obj) where T : TypeA
    {
        return list.Exists(item => item.Prop1 == obj);
    }

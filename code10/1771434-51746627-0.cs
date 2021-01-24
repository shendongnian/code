    public static int CountInner(IEnumerable<Obj> list)
    {
        var count = list.Where(l => l.InnerProperty).Count(); 
        return count;
    }

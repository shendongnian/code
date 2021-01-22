    public class MyList<T1, T2> : List<Tuple<IEnumerable<HashSet<T1>>, IComparable<T2>>> { }
    
    public void Meth()
    {
        var x = new MyList<int, bool>();
    }

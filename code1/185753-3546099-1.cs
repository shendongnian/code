    public static int Count(IEnumerable data) {
        ICollection list = data as ICollection;
        if(list != null) return list.Count;
        int count = 0;
        IEnumerator iter = data.GetEnumerator();
        using(iter as IDisposable) {
            while(iter.MoveNext()) count++;
        }
        return count;
    }

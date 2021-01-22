    public static int Count(IEnumerable data) {
        IList list = data as IList;
        if(list != null) return list.Count;
        int count = 0;
        IEnumerator iter = data.GetEnumerator();
        using(iter as IDisposable) {
            while(iter.MoveNext()) count++;
        }
        return count;
    }

    static T ElementAt<T>(IEnumerable<T> items, int index)
    {
        using(IEnumerator<T> iter = items.GetEnumerator())
        {
            for (int i = 0; i <= index; i++, iter.MoveNext()) ;
            return iter.Current;
        }
    } 

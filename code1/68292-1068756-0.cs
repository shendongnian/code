    public static void ForEachEx<T>(this IEnumerable<T> s, Action<T, bool> act)
    {
        IEnumerator<T> curr = s.GetEnumerator();
        if (curr.MoveNext())
        {
            bool last;
            while (true)
            {
                T item = curr.Current;
                last = !curr.MoveNext();
                
                act(item, last);
                
                if (last)
                    break;
            }
        }
    }

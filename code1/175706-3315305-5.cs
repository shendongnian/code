    public static class ForEachHelper
    {
        public sealed class Item<T>
        {
            public int Index { get; set; }
            public T Current { get; set; }
            public T Next { get; set; }
            public bool HasNext { get; set; }
        }
    
        public static IEnumerable<Item<T>> Wrap<T>(IEnumerable<T> enumerable)
        {
            IEnumerator<T> enumerator = enumerable.GetEnumerator();
            try
            {
                var item = new Item<T>();
                item.Index = 0;
                item.Current = default(T);
                item.Next = default(T);
                item.HasNext = false;
                if (enumerator.MoveNext())
                {
                    item.Current = enumerator.Current;
                    if (enumerator.MoveNext())
                    {
                        item.Next = enumerator.Current;
                        item.HasNext = true;
                    }
                    while (item.HasNext)
                    {
                        var next = new Item<T>();
                        next.Index = item.Index + 1;
                        next.Current = item.Next;
                        next.Next = default(T);
                        if (enumerator.MoveNext())
                        {
                            next.Next = enumerator.Current;
                            next.HasNext = true;
                        }
                        var current = item;
                        item = next;
                        yield return current;
                    }
                    yield return item;
                }
            }
            finally
            {
                enumerator.Dispose();
            }
        }
    }

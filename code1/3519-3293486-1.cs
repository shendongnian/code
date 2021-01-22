    public static class ForEachHelper
    {
        public sealed class Item<T>
        {
            public int Index { get; set; }
            public T Value { get; set; }
            public bool IsFirst { get { return Index == 0; } }
            public bool IsLast { get; set; }
        }
    
        public static IEnumerable<Item<T>> Wrap<T>(IEnumerable<T> enumerable)
        {
            IEnumerator<T> enumerator = enumerable.GetEnumerator();
            try
            {
                int index = 0;
                bool more = enumerator.MoveNext();
                while (more)
                {
                    var item = new Item<T>();
                    item.Index = index;
                    item.Value = enumerator.Current;
                    item.IsLast = false;
                    index++;
                    more = enumerator.MoveNext();
                    if (!more)
                    {
                        item.IsLast = true;
                    }
                    yield return item;
                }
            }
            finally
            {
                var disposable = enumerator as IDisposable;
                if (disposable != null)
                {
                    disposable.Dispose();
                }
            }
        }
    }

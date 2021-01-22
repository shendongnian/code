        public static void MyForEach<T>(this IEnumerable<T> items, Action<T> onFirst, Action<T> onMiddle, Action<T> onLast)
        {
            using (var enumerator = items.GetEnumerator())
            {
                if (enumerator.MoveNext())
                {
                    onFirst(enumerator.Current);
                }
                else
                {
                    return;
                }
                //If there is only a single item in the list, we treat it as the first (ignoring middle and last)
                if (!enumerator.MoveNext())
                    return;
                do
                {
                    var current = enumerator.Current;
                    if (enumerator.MoveNext())
                    {
                        onMiddle(current);
                    }
                    else
                    {
                        onLast(current);
                        return;
                    }
                } while (true);
            }
        }

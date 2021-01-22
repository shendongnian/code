        public static int? FirstEmptyIndex<T>(this IEnumerable<T> src)
        {
            using (IEnumerator<T> e = src.GetEnumerator())
            {
                int index = 0;
                while (e.MoveNext())
                {
                    if (e.Current == null)
                        return index;
                    else
                        index++;
                }
            }
            return null;
        }

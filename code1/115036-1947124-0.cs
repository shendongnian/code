        static int? FirstEmptyIndex<T>(this IEnumerable<T> src)
        {
            int? index = null;
            using (IEnumerator<T> e = src.GetEnumerator())
            {
                while (e.MoveNext())
                {
                    if (e.Current != null)
                        index++;
                    else
                        break;
                }
            }
            return index;
        }

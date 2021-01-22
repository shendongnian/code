    public static class ListExtensions
        {
            public static bool IsEqual<T>(this IList<T> list,IList<T> target, IComparer<T> comparer) where T:IComparable<T>
            {
                if (list.Count != target.Count)
                {
                    return false;
                }
                int index = 0;
                while (index < list.Count && 
                       comparer.Compare(list[index],target[index]) == 0)
                {
                    index++;
                }
                if (index != list.Count)
                {
                    return false;
                }
                return true;
            }
        }

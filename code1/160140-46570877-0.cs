     public static IList<T> InsertR<T>(this IList<T> ilist, int index, T item) {
            if (!(index < ilist.Count)) {
                T[] array = Array.CreateInstance(typeof(T), index + 1) as T[];
                ilist.CopyTo(array, 0);
                array[index] = item;
                if (ilist.GetType().IsArray) {
                    ilist = array;
                } else {
                    ilist = array.ToList();
                }
            } else
                ilist[index] = item;
            return ilist;
        }

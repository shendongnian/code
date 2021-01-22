    public static IList InsertR<T>(this IList ilist, int index, T item) {
    
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

    public static Nullable<T> RemoveLast<T>(this List<T> list) where T:struct
            {
                if (list.Count > 0)
                {
                    var item = list[list.Count - 1];
                    list.RemoveAt(list.Count - 1);
                    return (T)item;
                }
                return null;
            }

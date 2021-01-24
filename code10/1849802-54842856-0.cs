    public static T RemoveLast<T>(this List<T> list)
            {
                if (list.Count > 0)
                {
                    var item = list[list.Count - 1];
                    list.RemoveAt(list.Count - 1);
                    return item;
                }
                return default(T);
            }

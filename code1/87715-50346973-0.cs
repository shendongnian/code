    public static string EnumerateStrings<T>(this List<T> items, string separator = "; ")
    {
        var result = "";
        if(typeof(T) == typeof(string) && items.SafeAny())
        {
            items.ForEach(str => {
                try
                {
                    if (!String.IsNullOrEmpty(str as string))
                    {
                        if (!String.IsNullOrEmpty(result))
                            result += separator;
                        result += str;
                    }
                }
                catch { }
            });
        }
        return result;
    }

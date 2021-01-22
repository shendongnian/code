    using System.Linq;
    public static void ReplaceEmptyStrings<T>(List<T> list, string replacement)
    {
        var properties = typeof(T).GetProperties()
                                  .Where( p => p.PropertyType == typeof(string) );
        foreach(var p in properties)
        {
            foreach(var item in list)
            {
                if(string.IsNullOrEmpty((string) p.GetValue(item, null)))
                    p.SetValue(item, replacement, null);
            }
        }
    }

    public static bool FieldsEquals(this object o, object other)
    {
        if (ReferenceEquals(o, other)) return true;
        if (o == null || other == null || o.GetType() != other.GetType()) return false;
        foreach (var f in o.GetType().GetFields())
        {
            bool isEnumerable = f.GetValue(o).GetType().IsAssignableFrom(typeof(System.Collections.IEnumerable));// but is not a string
            if (!isEnumerable)
            {
                if (!f.GetValue(o).Equals(f.GetValue(other))) return false;
            }
            else
            {
                var first = ((System.Collections.IEnumerable)f.GetValue(o)).Cast<object>().ToArray();
                var second = ((System.Collections.IEnumerable)f.GetValue(other)).Cast<object>().ToArray();
                if (first.Length != second.Length)
                    return false;
                for (int i = 0; i < first.Length; i++)
                {
                    if (first[i] != second[i]) //assumes they are basic types, which implement equality checking. If they are classes, you may need to recursively call this method
                        return false;
                }
            }
        }
        return true;
    }

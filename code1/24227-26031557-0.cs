    private bool Compare(object obj1, object obj2)
    {
        if (obj1 == null || obj2 == null)
        {
            return false;
        }
        if (!obj1.GetType().Equals(obj2.GetType()))
        {
            return false;
        }
        Type type = obj1.GetType();
        if (type.IsPrimitive || typeof(string).Equals(type))
        {
            return obj1.Equals(obj2);
        }
        if (type.IsArray)
        {
            Array first = obj1 as Array;
            Array second = obj2 as Array;
            var en = first.GetEnumerator();
            int i = 0;
            while (en.MoveNext())
            {
                if (!Compare(en.Current, second.GetValue(i)))
                    return false;
                i++;
            }
        }
        else
        {
            foreach (PropertyInfo pi in type.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public))
            {
                var val = pi.GetValue(obj1);
                var tval = pi.GetValue(obj2);
                if (!Compare(val, tval))
                    return false;
            }
            foreach (FieldInfo fi in type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public))
            {
                var val = fi.GetValue(obj1);
                var tval = fi.GetValue(obj2);
                if (!Compare(val, tval))
                    return false;
            }
        }
        return true;
    }

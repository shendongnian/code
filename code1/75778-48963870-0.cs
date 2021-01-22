    public static object GetPropValue(this object obj, string name)
    {
        foreach (string part in name.Split('.'))
        {
            if (obj == null) { return null; }
            Type type = obj.GetType();
            if (type.Name == "__ComObject")
            {
                if (part.Contains('['))
                {
                    string partWithoundIndex = part;
                    int index = ParseIndexFromPropertyName(ref partWithoundIndex);
                    obj = Versioned.CallByName(obj, partWithoundIndex, CallType.Get, index);
                }
                else
                {
                    obj = Versioned.CallByName(obj, part, CallType.Get);
                }
            }
            else
            {
                PropertyInfo info = type.GetProperty(part);
                if (info == null) { return null; }
                obj = info.GetValue(obj, null);
            }
        }
        return obj;
    }
    private static int ParseIndexFromPropertyName(ref string name)
    {
        int index = -1;
        int s = name.IndexOf('[') + 1;
        int e = name.IndexOf(']');
        if (e < s)
        {
            throw new ArgumentException();
        }
        string tmp = name.Substring(s, e - s);
        index = Convert.ToInt32(tmp);
        name = name.Substring(0, s - 1);
        return index;
    }

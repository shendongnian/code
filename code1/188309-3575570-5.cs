    static Enum GetEnumValue(Type enumType, string name, bool ignoreCase){
        // null-checking omitted
        int index;
        if(ignoreCase)
            index = Array.FindIndex(Enum.GetNames(enumType),
                s => string.Compare(s, name, StringComparison.OrdinalIgnoreCase) == 0);
                // or StringComparison.CurrentCultureIgnoreCase or something if you
                // need to support fancy Unicode names
        else index = Array.IndexOf(Enum.GetNames(enumType), name);
        if(index < 0)
            throw new ArgumentException("\"" + name + "\" is not a value in " + enumType, "name");
        return Enum.GetValues(enumType).GetValue(index);
    }

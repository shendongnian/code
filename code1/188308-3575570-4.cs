    static Enum GetEnumValue(Type enumType, string name){
        // null-checking omitted for brevity
        int index = Array.IndexOf(Enum.GetNames(enumType), name);
        if(index < 0)
            throw new ArgumentException("\"" + name + "\" is not a value in " + enumType, "name");
        return Enum.GetValues(enumType).GetValue(index);
    }

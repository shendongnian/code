    public static Hashtable BindToEnum(Type enumType)
    {
        // get the names from the enumeration
        string[] names = Enum.GetNames(enumType);
        // get the values from the enumeration
        Array values = Enum.GetValues(enumType);
        // turn it into a hash table
        Hashtable ht = new Hashtable(names.Length);
    
        for (int i = 0; i < names.Length; i++)
            // Change Cap Case words to spaced Cap Case words
            // note the cast to integer here is important
            // otherwise we'll just get the enum string back again
            ht.Add(
                (int)values.GetValue(i),
                System.Text.RegularExpressions.Regex.Replace(names[i], "([A-Z0-9])", " $1", System.Text.RegularExpressions.RegexOptions.Compiled).Trim()
                );
        // return the dictionary to be bound to
        return ht;
    }

    public static string Insert(object dictionary, string into)
    {
        foreach (PropertyInfo property in dictionary.GetType().GetProperties())
            into = into.Replace("<%" + property.Name + "%>", 
                                property.GetValue(dictionary, null).ToString());
        return into;
    }

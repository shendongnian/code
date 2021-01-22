    public static List<T> EnumToList<T>(Enum someEnum)
    {
        List<T> list = new List<T>();
    
        foreach (var it in Enum.GetValues(someEnum.GetType()))
        {
            if ((Convert.ToByte(it) & Convert.ToByte(someEnum)) != 0)
            {
                list.Add((T)it);
            }
        }
    
        return list;
    }
    myRepeater.DataSource = EnumToList<Filters>(SelectedFilters);

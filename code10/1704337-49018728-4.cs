    public static IEnumerable<bool> ContainsValues(List<string> list1, List<string> list2)
    {
        return
            from item in list1
            from sub in list2
            select item.ToLower().Contains(sub.ToLower());
    }

    public static List<string> TrimList(this List<string> list)
    {
        foreach(var s in new List(list))
        {
            if(string.string.IsNullOrWhiteSpace(s))
            {
                list.Remove(s);
            }
            else
            {
                break;
            }
        }
        foreach(var s in new List(list).Reverse())
        {
            if(string.string.IsNullOrWhiteSpace(s))
            {
                list.Remove(s);
            }
            else
            {
                break;
            }
        }
    }

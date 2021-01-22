    public static List<string> TrimList(this List<string> list)
    {
        list.TrimListStart();
        vat l = list.Reverse().ToList();
        l.TrimListStart();
        return l;
    }
    public void TrimListStart(this List<string> list)
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
    }

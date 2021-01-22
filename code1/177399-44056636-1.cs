    public int GetIndex(String value)
    {
        var result = -1;
        if (!String.IsNullOrEmpty(value))
        {
            var list = (IList<Data1>)p_EM_Select_Event_TypeBindingSource.List;
            if (list.Any(x => x.Character == value))
            {
                result = list.IndexOf(list.First(x => x.Character == value));
            }
        }
        return result;
    }
    public int GetNumber(String value)
    {
        var result = -1;
        if (!String.IsNullOrEmpty(value))
        {
            var item = list.IndexOf(list.FirstOrDefault(x => x.Character == value));
            if (item != null)
            {
                result = item.Number;
            }
        }
        return result;
    }

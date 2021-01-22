    public static Dictionary<string, IHasKey> ConvertToDictionary(IList<IHasKey> myList) 
    {
        var dict = new Dictionary<string, IHasKey>();
        foreach (IHasKey item in myList)
        {
            dict.Add(item.LookUpKey, item);
        }
        return dict;
    }

    public IList CategoryIDs
    {
        get
        {
            return list.Split(new char[]{','}).ToList<string>();
        }
    }

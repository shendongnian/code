    public IList CategoryIDs
    {
        get
        {
            return list.Split(new char[]{','})
                       .ToList<string>()
                       .ConvertAll<int>(new Converter<string, int>(
                                 delegate(string s)
                                 {
                                     return int.Parse(s);
                                 }
                   ));;
        }
    }

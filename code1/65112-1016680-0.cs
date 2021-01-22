    Dictionary< char, double > dic = new Dictionary< char, double >();
    ...
    void AddItem(char c, double angle)
    {
        if (!dic.ContainsKey(c))
            dic.Add(c,angle);
    }

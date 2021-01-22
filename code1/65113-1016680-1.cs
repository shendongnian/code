    Dictionary< double, char> dic = new Dictionary< double, char>();
    ...
    void AddItem(char c, double angle)
    {
        if (!dic.ContainsKey(angle))
            dic.Add(angle,c);
    }

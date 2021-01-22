    Dictionary< double, char> dic = new Dictionary< double, char>();
    //Adding a new item
    void AddItem(char c, double angle)
    {
        if (!dic.ContainsKey(angle))
            dic.Add(angle,c);
    }
    //Retreiving an item
    char GetItem(double angle)
     {
        char c;
        if (!dic.TryGetValue(angle, out c))
            return '';
        else
            return c;   
     }
 

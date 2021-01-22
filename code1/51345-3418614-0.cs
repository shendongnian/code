    IEnumerable<string> stringEnumerable= new List<string>();
    stringList.Add("Comma");
    stringList.Add("Separated");
        
    string.Join<string>(",", stringEnumerable);

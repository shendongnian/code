    public static List<object> Solve(string input)
    {
        var list = new List<object>();
    
        list.Add(input);
        Recursive(input, list);
        return list;
    }       
    
    public static void Recursive(string input, List<object> list)
    {
        var first = input.Substring(0, input.Length / 2);
        var second = input.Substring(input.Length / 2);
    
        var innerList = new List<object>() { first };           
        list.Add(innerList);
        if(first.Length > 1)
            Recursive(first, innerList);
    
        innerList.Add(second);
        if (second.Length > 1)                
            Recursive(second, innerList);
    }

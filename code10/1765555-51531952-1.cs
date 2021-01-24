    public static List<object> Solve(string input)
    {
        var list = new List<object>();
    
        list.Add(input);
        Recursive(input, list);
        return list;
    }
    
    public static void Recursive(string input, List<object> list)
    {
        var middle = input.Length / 2;
        var first = input.Substring(0, middle);
        var second = input.Substring(middle);
    
        var innerList = new List<object>() { first };
    
        list.Add(innerList);
        if (first.Length > 1)
            Recursive(first, innerList);
    
        innerList.Add(second);
        if (second.Length > 1)
            Recursive(second, innerList);
    }
    
    public static void Show(object input)
    {
        if (!(input is string))
        {
            Console.Write("[");
            var list = input as List<object>;
            foreach (var item in list)
            {
                Show(item);
                if (item != list.Last())
                    Console.Write(", ");
            }
            Console.Write("]");
        }
        else
            Console.Write(input);
    }

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
        var innerList = new List<object>();           
        list.Add(innerList);
        foreach (var side in new[] { first, second })
        {
            innerList.Add(side);
            if (side.Length > 1)
                Recursive(side, innerList);
        }            
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

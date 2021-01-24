    public static List<object> Solve(string input, List<object> list = null)
    {
        if (list == null)
            return Solve(input, new List<object> { input });
        var middle = input.Length / 2;
        var first = input.Substring(0, middle);
        var second = input.Substring(middle);
        var innerList = new List<object>();                       
        list.Add(innerList);
        foreach (var side in new[] { first, second })
        {
            innerList.Add(side);
            if (side.Length > 1)
                Solve(side, innerList);
        }
        return list;
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

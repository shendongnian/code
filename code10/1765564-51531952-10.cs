    public static List<object> Solve(string input, List<object> list = null)
    {
        if (list == null)
            return Solve(input, new List<object> { input });
        if (input.Length > 1)
        {
            var first = input.Substring(0, input.Length / 2);
            var second = input.Substring(nput.Length / 2);
            var innerList = new List<object>();                       
            list.Add(innerList);
            foreach (var side in new[] { first, second })
            {
                innerList.Add(side);
                Solve(side, innerList);
            }
        }
        return list;
    }
    public static void Show(object input)
    {
        if (!(input is string))
        {
            Console.Write("[");
            foreach (var item in (input as List<object>))
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

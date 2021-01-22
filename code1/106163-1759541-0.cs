    //int[] x = SplitStringIntoInts("1,2,3, 4, 5");
    
    static int[] SplitStringIntoInts(string list)
    {
        string[] split = list.Split(new char[1] { ',' });
        List<int> numbers = new List<int>();
        int parsed;
    
        foreach (string n in split)
        {
            if (int.TryParse(n, out parsed))
                numbers.Add(parsed);
        }
    
        return numbers.ToArray();
    }

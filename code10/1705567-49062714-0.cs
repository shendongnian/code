    int[] GetUserInput()
    {
        var list = new List<int>();
        while (true)
        {
            Console.WriteLine("Enter a value or just press enter to indicate you are done.");
            var s = Console.ReadLine();
            if (string.IsNullOrEmpty(s)) break;
            list.Add(int.Parse(s));
        }
        return list.ToArray();
    }
 

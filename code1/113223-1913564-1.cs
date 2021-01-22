    using (IEnumerable<int> counter = new SaveableEnumerable<int>(CountableEnumerable()))
    {
        foreach (int i in counter)
        {
            Console.WriteLine(i);
            if (i > 10)
            {
                break;
            }
        }
        DoSomeStuff();
        foreach (int i in counter)
        {
            Console.WriteLine(i);
            if (i > 20)
            {
                break;
            }
        }
    }

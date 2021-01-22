    static void EnumerableVsEnumeratorStateTest()
    {
        IList<int> numList = new List<int>();
    
        numList.Add(1);
        numList.Add(2);
        numList.Add(3);
        numList.Add(4);
        numList.Add(5);
        numList.Add(6);
    
        Console.WriteLine("Using Enumerator - Remembers the state");
        IterateFrom1to3(numList.GetEnumerator());
    
        Console.WriteLine("Using Enumerable - Does not Remembers the state");
        IterateFrom1to3Eb(numList);
    
        Console.WriteLine("Using Enumerable - 2nd functions start from the item 1 in the collection");
    }
    static void IterateFrom1to3(IEnumerator<int> numColl)
    {
        while (numColl.MoveNext())
        {
            Console.WriteLine(numColl.Current.ToString());
    
            if (numColl.Current > 3)
            {
                // This method called 3 times for 3 items (4,5,6) in the collction. It remembers the state and displays the continued values.
                IterateFrom3to6(numColl);
            }
        }
    }
    static void IterateFrom3to6(IEnumerator<int> numColl)
    {
        while (numColl.MoveNext())
        {
            Console.WriteLine(numColl.Current.ToString());
        }
    }
    
    static void IterateFrom1to3Eb(IEnumerable<int> numColl)
    {
        foreach (int num in numColl)
        {
            Console.WriteLine(num.ToString());
    
            if (num>= 5)
            {
                // The below method invokes for the last 2 items.
                //Since it doesnot persists the state it will displays entire collection 2 times.
                IterateFrom3to6Eb(numColl);
            }
        }
    }
    static void IterateFrom3to6Eb(IEnumerable<int> numColl)
    {
        Console.WriteLine();
        foreach (int num in numColl)
        {
            Console.WriteLine(num.ToString());
        }
    }

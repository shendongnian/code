        Pair<string, string> thePair = new Pair<string, string>("1", "1");
        // Compare a new pair to previous pair by generating a second pair.
        if (thePair.Equals(new Pair<string, string>("1", "1")))
            System.Console.WriteLine("Equal");
        else
            System.Console.WriteLine("Not equal");
    The type Pair as you use it is Pair<T1, t2>

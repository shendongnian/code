        StringCollection s = new StringCollection();
        s.Add("s");
        s.Add("s");
        s.Add("t");
        var uniques = s.Cast<IEnumerable>();
        var unique = uniques.Distinct();
        foreach (var x in unique)
        {
            Console.WriteLine(x);
        }
        Console.WriteLine("Done");
        Console.Read();

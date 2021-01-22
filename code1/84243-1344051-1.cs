    string s = "nbHHkRvrXbvkn";
    Console.WriteLine( 
        s.ToCharArray()
            .GroupBy(c => c)
            .Where(g => g.Count() == 1)
            .Aggregate(new StringBuilder(), (b, g) => b.Append(g.Key)));

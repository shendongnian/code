    public void Linq40()
    {
        int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
    
        var numberGroups =
            from n in numbers
            group n by n % 5 into g
            select new { Remainder = g.Key, Numbers = g };
    
        foreach (var g in numberGroups)
        {
            Console.WriteLine("Numbers with a remainder of {0} when divided by 5:", g.Remainder);
            foreach (var n in g.Numbers)
            {
                Console.WriteLine(n);
            }
        }
    }

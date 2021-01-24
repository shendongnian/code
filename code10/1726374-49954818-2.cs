    public static void Compare_competitor(int[] newarray)
    {
        var indexes = Enumerable.Range(0, newarray.Length)
                                .Where(i => newarray[i] == newarray.Max())
                                .Select(i => i);
    
        foreach (var item in indexes)
        {
            Console.WriteLine("\nAnd the winner is competitor{0}", item + 1);
        }
    
        Console.WriteLine("with total scores of {0}", newarray.Max());
    }

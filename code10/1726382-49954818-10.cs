    public static void Compare_competitor(int[] newarray)
    {
        var indexes = Enumerable.Range(0, newarray.Length)
                                .Where(i => newarray[i] == newarray.Max())
                                .Select(i => i);
    
        List<string> winners = new List<string>();
        foreach (var item in indexes)
        {
            winners.Add(String.Format("Competitor {0}", item + 1));
        }
        Console.WriteLine("{0} are the highest with total score of {1}", 
                          string.Join(", ", winners), newarray.Max());
    }

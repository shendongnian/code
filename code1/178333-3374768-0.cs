    static void Main(string[] args)
    {
        var total =Seq()
                        .Where(counter => (counter%3 == 0) || (counter%5 == 0))
                        .Sum();
        Console.WriteLine(total);
        Console.ReadKey();
    }
    public static IEnumerable<int> Seq()
    {
        int i = 0;
        while (i < 1000)
        {
            yield return i++;
        }
    }

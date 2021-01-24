    static void Main()
    {
        var result = "";
        foreach (var c in NextInput(3))
        {
            result = c + " " + result;
        }
        Console.WriteLine(result);
    }
    private static IEnumerable<char> NextInput(int count)
    {
        var i = 0;
        while (i++ < count)
            yield return char.Parse(Console.ReadLine());
    }

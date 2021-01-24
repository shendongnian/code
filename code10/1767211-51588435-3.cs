    private static IEnumerable<int> ConstantEnumerable()
    {
        yield return 1;
        yield return 2;
        yield return 3;
    }
    private static int i = 0;
    private static IEnumerable<int> ChangingEnumerable()
    {
        if (i == 0)
        {
            yield return 1;
            i++;
        }
        else
        {
            yield return 2;
            yield return 3;
        }
    }
    public static void Main()
    {
        var constant = ConstantEnumerable();
        var changing = ChangingEnumerable();
		Console.WriteLine("Constant: {0}, {1}", constant.Count(), constant.Count());  // 3, 3
		Console.WriteLine("Changing: {0}, {1}", changing.Count(), changing.Count()); // 1, 2
    }

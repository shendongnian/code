    public static int Sum(this IEnumerable<int> source)
    {
        if (source == null)
        {
            throw Error.ArgumentNull("source");
        }
        int num = 0;
        foreach (int num2 in source)
        {
            num += num2;
        }
        return num;
    }

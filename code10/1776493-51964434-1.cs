    IEnumerable<int> c = testMethod.Invoke(obj, new Object[] { nodeChild }) as IEnumerable<int>;
    if (c != null)
    {
        int count;
        foreach (var progress in c)
        {
            Console.WriteLine(progress);
            count = progress;
        }
        Console.WriteLine(count);
    }

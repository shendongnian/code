    enum Operation { Added, Removed, }
    
    static void Main(string[] args)
    {
        var original = new int[] { 2, 1, 3 };
        var target = new int[] { 1, 3, 4 };
        var result = original.Except(target)
            .Select(i => new { Value = i, Operation = Operation.Removed, })
            .Concat(
                target.Except(original)
                .Select(i => new { Value = i, Operation = Operation.Added, })
                );
        foreach (var item in result)
            Console.WriteLine("{0}, {1}", item.Value, item.Operation);
    }

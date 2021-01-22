        int?[] nums = { 1, 3, 5 };
        var qry = nums.Where(i => i % 2 == 0);
        Console.WriteLine(qry == null); // false
        Console.WriteLine(qry.Count()); // 0
        var list = qry.ToList();
        Console.WriteLine(list.Count); // 0
        var first = qry.FirstOrDefault();
        Console.WriteLine(first == null); // true

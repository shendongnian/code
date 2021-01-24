    int[] a1 = { 42, 3, 9, 42, 42, 0, 42, 9, 42, 42, 17, 8, 2222, 4, 9, 0, 1 };
    int[] a2 = { 42, 2222, 9 };
    var zeros = Enumerable.Repeat(0, int.MaxValue);
    var valids = a1.Where(v => !a2.Contains(v));
    var result = valids.Concat(zeros).Take(a1.Length);
    Console.WriteLine(String.Join(", ", result));

    var values1 = new[] { 1, 2, 3, 4, 5 };
    foreach (var permutation in values1.GetPermutations())
    {
        Console.WriteLine(string.Join(", ", permutation));
    }
    var values2 = new[] { 'a', 'b', 'c', 'd', 'e' };
    foreach (var permutation in values2.GetPermutations())
    {
        Console.WriteLine(string.Join(", ", permutation));
    }
    Console.ReadLine();

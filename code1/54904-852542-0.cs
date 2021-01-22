    char[] items = new char[] { 'A', 'B', 'C', 'D', 'E' };
    		
    foreach (IEnumerable<char> permutation in PermuteUtils.Permute(items, 3)) {
        Console.Write("[");
        foreach (char c in permutation) {
            Console.Write(" " + c);
        }
        Console.WriteLine(" ]");
    }

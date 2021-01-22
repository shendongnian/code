    int[] list = CreateSomeList();
    Console.WriteLine(list.Length);  // O(1)
    IEnumerable<int> e1 = list;
    Console.WriteLine(e1.Count()); // O(1) 
    IEnumerable<int> e2 = list.Where(x => x <> 42);
    Console.WriteLine(e2.Count()); // O(N)

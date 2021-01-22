    [TestMethod] // or Console Application:
    static void Main(string[] args)
    {
        // This is our tree:
        //     4 
        //  2     6 
        // 1 3   5 7 
        var tree7 = new Tree<int>(4, new Tree<int>(2, new Tree<int>(1), new Tree<int>(3)),
                                new Tree<int>(6, new Tree<int>(5), new Tree<int>(7)));
        var sumTree = tree7.Aggregate((x, l, r) => x + l + r, 0);
        Console.WriteLine(sumTree); // 28
        Console.ReadLine();
    
        var inOrder = tree7.Aggregate((x, l, r) =>
            {
                var tmp = new List<int>(l) {x};
                tmp.AddRange(r);
                return tmp;
            }, new List<int>());
        inOrder.ForEach(Console.WriteLine); // 1 2 3 4 5 6 7
        Console.ReadLine();
            
        var heightTree = tree7.Aggregate((_, l, r) => 1 + (l>r?l:r), 0);
        Console.WriteLine(heightTree); // 3
        Console.ReadLine();
    }

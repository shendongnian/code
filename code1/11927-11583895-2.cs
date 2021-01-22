    [TestMethod]
    void TestMethod()
    {
        // This is our tree:
        //     4 
        //  2     6 
        // 1 3   5 7 
        var tree7 = new Tree<int>(4, new Tree<int>(2, new Tree<int>(1, null, null), new Tree<int>(3, null, null)),
                                new Tree<int>(6, new Tree<int>(5, null, null), new Tree<int>(7, null, null)));
        var sumTree = tree7.Aggregate((x, l, r) => x + l + r, 0);
        Console.WriteLine(sumTree); // 28
    
        var inOrder = tree7.Aggregate((x, l, r) =>
            {
                var tmp = new List<int>(l) {x};
                tmp.AddRange(r);
                return tmp;
            }, new List<int>());
        inOrder.ForEach(Console.WriteLine); // 1 2 3 4 5 6 7
            
        var heightTree = tree7.Aggregate((_, l, r) => 1 + (l>r?l:r), 0);
        Console.WriteLine(heightTree); // 3
    }

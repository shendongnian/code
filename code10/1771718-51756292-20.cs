    TreeNode<A> node;
    var tree = new Tree<A>();
    tree.Root.Data = new B { Index = 0 };            // NodeClassB
    tree.Root.AddChild(new C { Index = 1 });         // __NodeClassC
    node = tree.Root.AddChild(new A { Index = 2 });  // __NodeClassA
    node.AddChild(new B { Index = 3 });              // ____NodeClassB
    node.AddChild(new B { Index = 4 });              // ____NodeClassB
    node.AddChild(new A { Index = 5 });              // ____NodeClassA
    node = tree.Root.AddChild(new A { Index = 6 });  // __NodeClassA
    node.AddChild(new C { Index = 7 });              // ____NodeClassC
    tree.Root.AddChild(new B { Index = 8 });         // __NodeClassB
    tree.Root.AddChild(new C { Index = 9 });         // __NodeClassC 

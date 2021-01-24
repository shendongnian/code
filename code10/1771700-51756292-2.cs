    var tree = new Tree<A>();                
    tree.Root.Data = new B();                // NodeClassB
    tree.Root.AddChild(new C());             // __NodeClassC
    var node = tree.Root.AddChild(new A());  // __NodeClassA
    node.AddChild(new B());                  // ____NodeClassB
    node.AddChild(new B());                  // ____NodeClassB
    node.AddChild(new A());                  // ____NodeClassA
    var node = tree.Root.AddChild(new A());  // __NodeClassA
    node.AddChild(new C());                  // ____NodeClassC
    tree.Root.AddChild(new B());             // __NodeClassB
    tree.Root.AddChild(new C());             // __NodeClassC 

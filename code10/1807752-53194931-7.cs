    static void Main(string[] args)
    {
        var nodeString = "(A(B(C(L()())(M()()))(D()()))(E(F(G(H()())())(I()(J()())))(K()())))";
        var rootNode = Node.Parse(nodeString);
        rootNode.Print();
        Console.Write("\nDone! Press any key to exit...");
        Console.ReadKey();
    }

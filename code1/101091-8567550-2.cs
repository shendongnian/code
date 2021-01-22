    public static void PrintTree(Node tree, String indent, Bool last)
    {
        Console.Write(indent + "+- " + tree.Name);
        indent += last ? "   " : "|  ";
        for (int i == 0; i < tree.Children.Count; i++)
        {
            PrintTree(tree.Children[i], indent, i == tree.Children.Count - 1);
        }
    }

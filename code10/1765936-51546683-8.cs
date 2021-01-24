    static void PrintTree(TreeNode node, int indents)
    {
        for (int tab = 0; tab < indents; tab++)
        {
            Console.Write("\t");
        }
        Console.WriteLine("{0} - {1}", node.Id, node.Name);
        if (node.Children != null && node.Children.Count > 0)
        {
            indents++;
            foreach (var child in node.Children)
            {
                PrintTree(child, indents);
            }
        }
    }

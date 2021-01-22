    static void Main(string[] args)
    {
        var n = LoadDirectory(@"E:\Share");
        Console.WriteLine(n.ToString());
        Console.ReadLine();
    }
    
    private class Node
    {
        public List<Node> Children = new List<Node>();
        public string Name;
    
        public override string ToString()
        {
            return ToString(1);
        }
    
        public string ToString(int depth)
        {
            if (Children.Count == 0)
            {
                return Name;
            }
            var sb = new StringBuilder(Name);
            foreach (var n in Children)
            {
                sb.AppendLine();
                sb.Append("".PadLeft(depth, '\t') + n.ToString(depth + 1));
            }
            return sb.ToString();
        }
    }
    
    private static Node LoadDirectory(string path)
    {
        var n = new Node() { Name = path };
        LoadDirectories(path, n);
        return n;
    }
    
    private static void LoadDirectories(string currentPath, Node node)
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(currentPath);
        DirectoryInfo[] directories = directoryInfo.GetDirectories();
    
        foreach (DirectoryInfo dir in directories)
        {
            if ((dir.Attributes & FileAttributes.System) != FileAttributes.System &&
                (dir.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
            {
                var n = new Node() { Name = dir.Name };
                node.Children.Add(n);
                LoadDirectories(dir.FullName, n);
            }
        }
    }

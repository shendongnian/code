    static void Main(string[] args)
    {
        var treeNodes = new List<TreeNode>();
        var dataTable = GetDataTableData();
        foreach (var data in dataTable)
        {
            treeNodes.Add(new TreeNode() { Id = data.Id, Name = data.Name, ParentID = data.ParentID });
        }
        var root = BuildTree(treeNodes);
        Console.ReadLine();
    }

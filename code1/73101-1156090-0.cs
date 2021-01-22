    protected void Page_Load(object sender, EventArgs e)
	{
		GenerateTreeView(@"C:\WINDOWS\");
	}
	private void GenerateTreeView(string rootPath)
	{
		GetFolders(System.IO.Path.GetFullPath(rootPath), TreeViewFolders.Nodes);
		TreeViewFolders.ExpandDepth = 1;
	}
	// recursive method to load all folders and files into tree
	private void GetFolders(string path, TreeNodeCollection nodes)
	{
		// add nodes for all directories (folders)
		string[] dirs = Directory.GetDirectories(path);
		foreach (string p in dirs)
		{
			string dp = p.Substring(path.Length);
			nodes.Add(Node("", p.Substring(path.Length), "folder"));
		}
		// add nodes for all files in this directory (folder)
		string[] files = Directory.GetFiles(path, "*.*");
		foreach (string p in files)
		{
			nodes.Add(Node(p, p.Substring(path.Length), "file"));
		}
		// add all subdirectories for each directory (recursive)
		for (int i = 0; i < nodes.Count; i++)
		{
			if (nodes[i].Value == "folder")
				GetFolders(dirs[i] + "\\", nodes[i].ChildNodes);
		}
	}
	// create a TreeNode from the specified path, text and type
	private TreeNode Node(string path, string text, string type)
	{
		TreeNode n = new TreeNode();
		n.Value = type;
		n.Text = text;
		return n;
	}

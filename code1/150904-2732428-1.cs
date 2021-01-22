	class TreeItem
	{
		public string FolderName;
		public List<TreeItem> SubFolders = new List<TreeItem>();
		public string[] Files;
	}
		
	class Program
	{
		
		private static TreeItem FileTree(string rootFolder){
			var item = new TreeItem();
			item.FolderName = rootFolder;
			item.Files = System.IO.Directory.GetFiles(rootFolder);
			
			foreach(var folder in System.IO.Directory.GetDirectories(rootFolder))
			{
				item.SubFolders.Add(FileTree(folder));
			}
			return item;
		}
		//Traversal algorithm
        private static void PrintComposite(TreeItem node, int ident)
		{
			var dirName = System.IO.Path.GetFileName(node.FolderName);
			Console.WriteLine(@"{0}{1}", new string('-', ident), dirName);
			foreach(var subNode in node.SubFolders)
			{
				PrintComposite(subNode, ident + 1);
			}
		}
		
		public static void Main(string[] args)
		{
			var tree = FileTree(@"D:\Games");
			PrintComposite(tree,0);
		}	
    }

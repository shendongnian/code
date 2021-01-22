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
		
		public static void Main(string[] args)
		{
			var tree = FileTree(@"D:\Games");
		}
	}

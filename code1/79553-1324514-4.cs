    public class FolderList : ObservableCollection<TreeItem>
    {
        public FolderList()
        {
            this.Add(new TreeItem { Name = "Hello" });
            this.Add(new TreeItem { Name = "World" });
            var folder = new Folder { Name = "Hello World" };
            folder.Items.Add(new TreeItem { Name = "Testing" });
            folder.Items.Add(new TreeItem { Name = "1" });
            folder.Items.Add(new TreeItem { Name = "2" });
            folder.Items.Add(new TreeItem { Name = "3" });
            this.Add(folder);
        }
    }

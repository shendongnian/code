    public class Folder : ITreeItem
    {
        public Folder(string name)
        {
            Name = name;
            Children = new BindingList<ITreeItem>();
        }
    
        public string Name { get; set; }
    
        public BindingList<ITreeItem> Children { get; private set; }
    }

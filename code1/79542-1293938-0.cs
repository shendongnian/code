    interface ITreeItem
    {
        IEnumerable<ITreeItem> GetChildren();
    }
    
    class MyFolder : ITreeItem
    {
        public IEnumerable<ITreeItem> GetChildren()
        {
            // TODO: Return the list of children
        }
    }
    
    class MyITreeItem : ITreeItem
    {
        public IEnumerable<ITreeItem> GetChildren()
        {
            // TODO: Return the list of children
        }
    }

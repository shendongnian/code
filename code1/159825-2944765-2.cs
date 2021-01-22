    interface ITreeNode<T>
        where T : ITreeNode
    {
        string Name { get; set; }
        ObservableCollection<T> Children { get; }
    }

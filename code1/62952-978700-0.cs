    public class TreeNodeCheckedChangedEventArgs : EventArgs
    {
        TreeNodeCheckedChangedEventArgs(int nodeKey)
        {
            NodeKey = nodeKey;
        }
        int NodeKey { get; private set; }
    }
        

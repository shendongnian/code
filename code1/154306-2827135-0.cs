    public class TreeNode : ITreeNode
    {
        private bool _isReadOnly;
        private List<ITreeNode> _childNodes = new List<ITreeNode>();
        public TreeNode Parent { get; private set; }
        public IEnumerable<ITreeNode> ChildNodes
        {
            get
            {
                return _isReadOnly ? _childNodes.AsReadOnly() : _childNodes;
            }
        }
    }

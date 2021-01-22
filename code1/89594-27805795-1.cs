    public sealed class TaggedTreeNode : TreeNode {
       object _Tag;
       public object Tag { get { return _Tag; } set { _Tag = value; } }
       ...
       protected internal TaggedTreeNode(TreeView owner, bool isRoot)
       : base(owner, isRoot) {
       }

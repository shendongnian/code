    public sealed class TaggedTreeView : TreeView {
       protected override TreeNode CreateNode() {
          return new TaggedTreeNode(this, false);
       }
    }

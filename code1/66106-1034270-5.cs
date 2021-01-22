    public class Item : TreeNode {
      public Item(int n, Category c) : base(n, c) {}
      public override string Tag { get { return "Item"; } }
    }
    public class Category : TreeNode {
      List<TreeNode> kids = new List<TreeNode>();
      public Category(int n, Category c) : base(n, c) {}
      public void AddChild(TreeNode child) {
        kids.Add(child);
      }
      public override string Tag { get { return "Category"; } }
      public override IList<TreeNode> Children {
        get { return kids; }
      }
    }

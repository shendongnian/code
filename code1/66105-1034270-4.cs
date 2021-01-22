    public abstract class TreeNode {
      private readonly int name;
      private Category c = null;
      public int Name { get { return name; } }
      public Category Parent { get { return c; } }
      public abstract string Tag { get; }
      public TreeNode(int n, Category c) {
        this.name = n;
        AssignCategory(c);
      }
      public void AssignCategory(Category c) {
        if (c != null) {
          this.c = c;
          c.AddChild(this);
        }
      }
      public virtual IList<TreeNode> Children {
        get { return null; }
      }
    }

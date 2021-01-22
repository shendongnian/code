    public class CornyTextView {
      public int NodeDepth(TreeNode n) {
        if (n.Parent == null)
          return 0;
        else
          return 1 + NodeDepth(n.Parent);
      }
      public void Display(IEnumerable<TreeNode> nodes) {
        foreach (var n in nodes.OrderBy(n => n.Name)) {
          for (int i = 0; i < NodeDepth(n); i++)
            Console.Write("  ");
          Console.WriteLine("- " + n.Tag + " " + n.Name.ToString());
          if (n.Children != null)
            Display(n.Children);
        }
      }
    }

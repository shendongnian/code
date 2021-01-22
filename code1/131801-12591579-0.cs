    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PopulateTreeView(treeView1, SampleData());
        }
        
        private IEnumerable<Item> SampleData()
        {
            yield return new Item { CaseID = "1" };
            yield return new Item { CaseID = "2" };
            yield return new Item { CaseID = "3" };
            yield return new Item { CaseID = "4", ParentID = "5" };
            yield return new Item { CaseID = "5", ParentID = "3" };
            yield return new Item { CaseID = "6" };
            yield return new Item { CaseID = "7", ParentID = "1" };
            yield return new Item { CaseID = "8", ParentID = "1" };
        }
        private void PopulateTreeView(TreeView tree, IEnumerable<Item> items)
        {
            Dictionary<string, Tuple<Item, TreeNode>> allNodes = new Dictionary<string, Tuple<Item, TreeNode>>();
            foreach (var item in items)
            {
                var node = CreateTreeNode(item);
                allNodes.Add(item.CaseID, Tuple.Create(item, node));
            }
            foreach (var kvp in allNodes)
            {
                if (kvp.Value.Item1.ParentID != null)
                {
                    allNodes[kvp.Value.Item1.ParentID].Item2.Nodes.Add(kvp.Value.Item2);
                }
                else
                {
                    tree.Nodes.Add(kvp.Value.Item2);
                }
            }
        }
        private TreeNode CreateTreeNode(Item item)
        {
            var node = new TreeNode();
            node.Text = item.CaseID;
            return node;
        }
    }
    public class Item
    {
        public string CaseID { get; set; }
        public string ParentID { get; set; }
    }

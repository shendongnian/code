    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PopulateTreeView(treeView, SampleData());
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
                allNodes.Add(item.CaseID, Tuple.New(item, node));
            }
            foreach (var kvp in allNodes)
            {
                if (kvp.Value.First.ParentID != null)
                {
                    allNodes[kvp.Value.First.ParentID].Second.Nodes.Add(kvp.Value.Second);
                }
                else
                {
                    tree.Nodes.Add(kvp.Value.Second);
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
    public class Tuple<T>
    {
        public Tuple(T first)
        {
            First = first;
        }
        public T First { get; set; }
    }
    public class Tuple<T, T2> : Tuple<T>
    {
        public Tuple(T first, T2 second)
            : base(first)
        {
            Second = second;
        }
        public T2 Second { get; set; }
    }
    public static class Tuple
    {
        //Allows Tuple.New(1, "2") instead of new Tuple<int, string>(1, "2")
        public static Tuple<T1> New<T1>(T1 t1)
        {
            return new Tuple<T1>(t1);
        }
        public static Tuple<T1, T2> New<T1, T2>(T1 t1, T2 t2)
        {
            return new Tuple<T1, T2>(t1, t2);
        }
    }

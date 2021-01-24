    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Forms.Integration;
    using System.Windows.Media;
    public class MyTreeView : System.Windows.Forms.UserControl, ISupportInitialize
    {
        private ElementHost elementHost = new ElementHost();
        private TreeView tree;
        private System.Windows.Forms.TreeView winFormsTree;
        public MyTreeView()
        {
            tree = new TreeView();
            winFormsTree = new System.Windows.Forms.TreeView();
            Nodes = winFormsTree.Nodes;
            tree.LayoutTransform = new RotateTransform(180);
            tree.FlowDirection = FlowDirection.RightToLeft;
            elementHost.Dock = System.Windows.Forms.DockStyle.Fill;
            elementHost.Name = "elementHost";
            elementHost.Child = tree;
            Controls.Add(elementHost);
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public System.Windows.Forms.TreeNodeCollection Nodes { get; }
        public void BeginInit() { }
        public void RefreshTree()
        {
            tree.Items.Clear();
            RefreshTree(tree.Items, Nodes);
        }
        private void RefreshTree(ItemCollection items, 
            System.Windows.Forms.TreeNodeCollection nodes)
        {
            foreach (System.Windows.Forms.TreeNode node in nodes)
            {
                var item = new TreeViewItem();
                var label = new Label();
                label.LayoutTransform = new RotateTransform(180);
                label.Content = node.Text;
                label.Padding = new Thickness(0);
                item.Header = label;
                items.Add(item);
                RefreshTree(item.Items, node.Nodes);
            }
        }
        public void EndInit()
        {
            RefreshTree();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing && winFormsTree != null)
                winFormsTree.Dispose();
            base.Dispose(disposing);
        }
    }

    public class Node
        {
            public string data;
            public Node left { get; set; }
            public Node right { get; set; }
    
            public Node(string data)
            {
                this.data = data;
            }
        }
        public class Tree
        {
            public Node root;
            public Tree()
            {
                root = null;
            }
            public void insert(string data)
            {
                Node newItem = new Node(data);
                if (root == null)
                {
                    root = newItem;                
                }
                else
                {
                    TreeNode sub = new TreeNode();
                    Node current = root;
                    Node parent = null;
                    while (current != null)
                    {
                        parent = current;
                        if (String.Compare(data, current.data) < 0)
                        {
                            current = current.left;
                            if (current == null)
                            {
                                parent.left = newItem;
                            }
                        }
                        else
                        {
                            current = current.right;
                            if (current == null)
                            {
                                parent.right = newItem;
                            }
                        }
                    }
                }
            }
        }
    
     
    
        public partial class Form1 : Form
        {
    
            void ShowNode(Node node,TreeNode treeNode)
            {
                treeNode.Text += node.data;
                if (node.left != null)
                {
                    ShowNode(node.left, treeNode.Nodes.Add("Left: "));
                }
                if (node.right != null)
                {
                    ShowNode(node.right, treeNode.Nodes.Add("Right: "));
                }
            }
            void DisplayTree(Tree tree)
            {
                ShowNode(tree.root,treeView1.Nodes.Add("Root: "));
            }
            public Form1()
            {
                InitializeComponent();
                Tree tree = new Tree();
                tree.insert("computer");
                tree.insert("code");
                tree.insert("programming");
                tree.insert("analyzing");
                tree.insert("cooler");
                tree.insert("and");
                DisplayTree(tree);
            }
        }

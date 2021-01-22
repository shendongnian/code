    public partial class Form1 : Form
    {
       public Form1()
       {
          InitializeComponent();
          this.treeView1.ImageList = ImageListManager.Instance.ImageList;
       }
       // Making some guesses about how you are adding nodes
       // and getting the associated image.
       public void AddNewTreeNode(string text, string imageKey, Image image)
       {
          TreeNode node = new TreeNode("display text");
          node.Name = "uniqueName";
          // This tells the new node to use the image in the TreeView.ImageList
          // that has imageKey as its key.
          node.ImageKey = imageKey;
          node.SelectedImageKey = imageKey;
          this.treeView1.Nodes.Add(node);
          // If the image doesn't already exist, this will add it.
          ImageListManager.Instance.AddImage(imageKey, image);
       }
    }

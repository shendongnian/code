    public partial class Form1 : Form
    {
       public Form1()
       {
          InitializeComponent();
          this.treeView1.ImageList = ImageListManager.Instance.ImageList;
       }
    }

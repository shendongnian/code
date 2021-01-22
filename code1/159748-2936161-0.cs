namespace Rekursive
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            iloader MyLoad = new TreeViewLoad();
            ((TreeViewLoad)MyLoad).TreeLoader(treeView1);
        }
    }
    interface iloader
    {
        void loader(string nodeName, TreeView myTre, int id);
    }
    class TreeViewLoad : iloader
    {
        public void TreeLoader(TreeView myTre)
        {
            loader("test", myTre, 1);
        }
        public void loader(string nodeName, TreeView myTre, int id)
        {
            myTre.Nodes.Add(nodeName + id.ToString());
            if (id < 10)
            {
                id++;
                loader(nodeName, myTre, id);
            }
        }
    }
}

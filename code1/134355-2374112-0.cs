    // requires declaration of : using System.Windows.Forms;
    // sample data class
    public class data
    {
        public string Name;
        public int ID;
    }
    public class XTreeNode : TreeNode
    {
        List<data> theData = new List<data>();
        public XTreeNode(string theNodeID)
        {
            this.Text = theNodeID;
        }
        public void addData(data newData)
        {
            theData.Add(newData);
        }
    }

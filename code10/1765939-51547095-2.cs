    public class TreeNode  
    {
        public string id { get; set; }
        public string name { get; set; }
        public string parentID { get; set; }
        public List<TreeNode> children { get; set; }
        public TreeNode() {
            children = new List<TreeNode>();
        }
        public TreeNode FindParentWithID(string ID)
        {
            TreeNode ParentWithID = null;
            //check my parentID if i am the one being looked for then return
            if (id == ID) return this;
            //search children
            foreach (TreeNode treeNode in children)
            {
                ParentWithID = treeNode.FindParentWithID(ID);
                if (ParentWithID != null)
                {
                    break;
                }
            }
            return ParentWithID;
        }
    }

    public static TreeNodeCollectionExtensions
    {
        public static TreeNode GetNodeByTag(this TreeNodeCollection tnc, object tag)
        {
            return tnc.Cast<TreeNode>().Where(n=>n.Tag == tag).SingleOrDefault();        
        }
    
    }

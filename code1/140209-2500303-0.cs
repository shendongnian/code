    public class TreeNodeEx : TreeNode {
        // only displayed when having no children
        public int Value { get; set; }
        public bool HasChildren {
            get { return Nodes.Count > 0; }
        }
        
        public int GetSumOfChildren() {
            if (!HasChildren)
                return Value;
            
            var children = Nodes.Cast<TreeNode>().OfType<TreeNodeEx>();
            
            int sum = 0;
            foreach (var child in children)
                sum += child.GetSumOfChildren();
            
            return sum;
        }
    }

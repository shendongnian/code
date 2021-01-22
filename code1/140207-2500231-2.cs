    public class TotalingTreeNode : TreeNode
    {
        private int _value = 0;
        public int Value 
        { 
            get
            {
               if (this.Nodes.Count > 1)
                  return GetTotaledValue();
               else 
                   return _value;
            } 
            set
            {
               if (this.Nodes.Count < 1)
                  _value = value;
            }
        }
   
        private int GetTotaledValue()
        {
            foreach (TotalingTreeNode t in this.Nodes.Cast<TotalingTreeNode>())
            {
                _value += t.Value;
            }
            return _value;
        }
    }

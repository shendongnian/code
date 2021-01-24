    public class NodeComparer : IEqualityComparer<Node>
    {
        public bool Equals(Node me, Node another) 
        {
            if (me.Header == another.Header) 
            {
                me.Items = me.Items.Union(another.Items, new NodeComparer()).ToList();
                return true;
            }
    
            return false;
        }
        public int GetHashCode(Node dic) 
        {
            return dic.Header.GetHashCode();
        }
    }

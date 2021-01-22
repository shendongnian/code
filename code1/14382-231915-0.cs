    public interface INode
    {
        IEnumerable<Node> GetChildren();
    }
    public class NodeWithTenChildren : INode
    {
        private Node[] m_children = new Node[10];
        public IEnumerable<Node> GetChildren()
        {
            for( int n = 0; n < 10; ++n )
            {
                yield return m_children[ n ];
            }
        }
    }
    public class NodeWithNoChildren : INode
    {
        public IEnumerable<Node> GetChildren()
        {
            yield break;
        }
    }

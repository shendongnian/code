    public class Node
    {
        // Properties
        public IEnumerable<Node> AllNodes
        {
            get
            {
                yield return this;
                foreach (var node in Nodes.SelectMany(n => n.AllNodes))
                    yield return node;
            }
        }
    }

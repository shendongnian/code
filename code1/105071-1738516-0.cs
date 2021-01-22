    public class Node
    {
        // Properties as before
        public Node FindById(Guid id)
        {
            if (id == Id)
            {
                return this;
            }
            foreach (Node node in Nodes)
            {
                Node found = node.FindById(id);
                if (found != null)
                {
                    return found;
                }
            }
            return null; // Not found in this subtree
        }
    }

    public class NodeTraverser
    {
        private static KeyValuePair<bool, IEnumerable<Node>> GetChildrenById(string text, Node node)
        {
            if(node.Text == text)
            {
                return new KeyValuePair<bool,IEnumerable<Node>>(true, node.Children);
            }
            foreach(var child in node.Children)
            {
                var result = GetChildrenById(text, child);
                if(result.Key)
                {
                    return result; // early out
                }
            }
            return new KeyValuePair<bool,IEnumerable<Node>>(false, Enumerable.Empty<Node>());
        }
        public static IEnumerable<Node> FindChildrenbyId(string text, Node root)
        {
            return GetChildrenById(text, root).Value; 
        }
    }

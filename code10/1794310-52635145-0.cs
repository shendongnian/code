    //The node
    public class Node
    {
        public Node[] connectedNodes;
        public bool rootNode;
    }
    
    //The function
    public static bool HasRootNode(Node fromNode)
    {
        List<Node> Processed = new List<Node>();
        Stack<Node> WorkStack = new Stack<Node>(FromNode.connectedNodes);
    
        Processed.Add(fromNode);
    
        while (WorkStack.Count != 0)
        {
            Node workItem = WorkStack.Pop();
            if (workItem.rootNode)
                return true; // Found..
             
            foreach (Node cNode in workItem.connectedNodes)
            {
                if (Processed.Contains(cNode))
                    continue;
    
                if (cNode.rootNode)
                    return true; // Found..
    
                WorkStack.Push(cNode); // Queue all of the connectedNodes for this node
                Processed.Add(cNode); // This node has been processed..
            }
        }
    
        return false; // Not found..
    }

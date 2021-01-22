    public LinkedList<T> SplitAfter(Node node)
    {
        Node nextNode = node.Next;
        // break the chain
        node.Next = null;
        nextNode.Previous = null;
        return new LinkedList<T>(nextNode);
    }
    public void RemoveAllNodesAfter(Node node)
    {
        SplitAfter(node);
    }

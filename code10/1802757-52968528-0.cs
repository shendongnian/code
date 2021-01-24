    public void Merge(List b)
    {
        Node lastNode = GetLastNode();
    
        if (lastNode != null)
        {
            lastNode.Next = b.firstNode;
        }
        else 
        {
            this.firstNode = b.firstNode;
        }
    }
    
    private Node GetLastNode()
    {
        if (this.firstNode == null)
        {
            return null;
        }
    
        Node current = this.firstNode;
    
        while (current.Next != null)
        {
            current = current.Next;
        }
    
        return current;
    }

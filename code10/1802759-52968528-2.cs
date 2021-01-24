    public void Print()
    {
        Node currentNode = this.firstNode;
    
        while(currentNode != null)
        {
            Console.Write(currentNode.Data + ' ');
            currentNode = currentNode.Next;
        }
    }

    public void Search(Node node, object data)
    {
        if(node.Data.Equals(data))
        {
            throw new ResultException(node);
        }
        else
        {
            Search(node.LeftChild, data);
            Search(node.RightChild, data);
        }    
    }

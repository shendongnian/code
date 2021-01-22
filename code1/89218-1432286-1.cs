    a->b->c->d
    
        a->null
         b->null
          c->null
          c<-d
         b<-c
        a<-b
    
    a<-b<-c<-d
    public void Reverse()
    {
        Reverse(Initial);
    }
    
    private void Reverse(Node node)
    {
        Node nextNode;
    
        if(node != null)
        {
            nextNode = node.Next
            node.Next = null;
            Reverse(nextNode);
            if(nextNode != null) nextNode.Next = node;
        }
    }

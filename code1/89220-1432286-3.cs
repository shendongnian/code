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
        if(node != null && node.Next != null)
        {
            //go deeper
            Reverse(node.Next);
            //swap
            node.Next.Next = node
            node.Next = null;
        }
    }

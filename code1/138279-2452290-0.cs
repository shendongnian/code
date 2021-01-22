    public new bool Remove()
    {
       bool removed = base.Remove();
       if(removed)
       {
           OnRemoved();
       }
       return removed;
    }

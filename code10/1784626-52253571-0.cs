    public DoStuff<T>(LinkedList<T> list)
    {
        var node = list.First;
        while(node != null)
        {
            // do stuff with node
            node = node.Next;
        }
    }

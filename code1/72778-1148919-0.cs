    public static Node Duplicate(Node n)
    {
        if (n == null)
            return null;
    
        return new Node() {
            Data = n.Data,
            Next = Duplicate(n.Next)
        };
    }

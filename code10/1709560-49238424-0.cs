    public void Insert(int x)
    {
        Node a = new Node(x);
        if (Head == null)
        {
            Head = Tail = a;
        }
        else
        {
            Tail.Next = a;
            Tail = a;
        }
    }

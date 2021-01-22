    public MyObject Value { get; set; }
    public static Node Create(MyObject value)
    {
       Node n = new Node();
       n.Value = value;
       MyObject childValue = value.FindChild(); // or however you find the child MyObject
       Node child = n.Children.Add(Node.Create(childValue));
       child.Parent = n;
       return n;
    }

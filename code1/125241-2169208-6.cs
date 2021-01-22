    public MyObject Value { get; set; }
    public static Node Create(MyObject value)
    {
       Node n = new Node();
       n.Value = value;
       foreach (string childKey in value.Children)
       {
          MyObject childValue = FindMyObject(childKey);
          Node child = n.Children.Add(Node.Create(childValue));
          child.Parent = n;
       } 
       return n;
    }

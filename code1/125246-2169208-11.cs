    public string Value { get; set; }
    public static Node Create(string parentKey)
    {
       Node n = new Node();
       n.Value = parentKey;
       foreach (string childKey in FindChildren(parentKey))
       {
          Node child = n.Children.Add(Node.Create(childKey));
          child.Parent = n;
       } 
       return n;
    }

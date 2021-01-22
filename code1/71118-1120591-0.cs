    public class Node
    {
      public Node Parent {get;set;} // null for roots
    
      public NodeCollection Children {get; private set;}
    
      public Node() 
      { 
        Children = new NodeCollection(); 
        Children.ChildAdded += ChildAdded;
        Children.ChildRemoved += ChildRemoved;
      };
      private void ChildAdded(object sender, NodeEvent args)
      {
        if(args.Child.Parent != null)
          throw new ParentNotDeadYetAdoptionException("Child already has parent");
        args.Child.Parent = this;
      }
      private void ChildRemoved(object sender, NodeEvent args)
      {
        args.Child.Parent = null;
      }
    }

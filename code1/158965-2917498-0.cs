    public class Node
    {
      //initialise non-null, so we can use the MemberMemberBinding
      private NodeData _data = new NodeData();
      public NodeData Data { get { return _data; } set { _data = value; } }
      //initialise with one element so you can see how a MemberListBind
      //actually adds elements to those in a list, not creating it new.
      //Note - can't set the element to 'new Node()' as we get a Stack Overflow!
      private IList<Node> _children = new List<Node>() { null };
      public IList<Node> Children 
        { get { return _children; } set { _children = value; } }
    }
    public class NodeData
    {
      private static int _counter = 0;
      //allows us to count the number of instances being created.
      public readonly int ID = ++_counter;
      public string Name { get; set; }
    }

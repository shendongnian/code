    interface MNode {
      MNode Parent { get; }
    }
    static class MNodeCode {
      public static void Method1(this MNode self) { /*...*/ }
      public static void Method2(this MNode self) { /*...*/ }
      /* ... */
      public static void Method30(this MNode self) { /*...*/ }
    }
    class Node : MNode {
      public Node Parent { get { ... } }
      MNode MNode.Parent { get { return Parent; } }
    }
    class Element : Node { public Dictionary<string, string> Attributes; }
    class Document : Element { }
    class ExtraNode : MNode {
      public ExtraNode Parent { get { ... } }
      MNode MNode.Parent { get { return Parent; } }
    }
    class ExtraElement : ExtraNode { public Dictionary<string, string> Attributes; }
    class ExtraDocument : ExtraElement { }

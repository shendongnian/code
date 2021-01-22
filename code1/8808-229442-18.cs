    class Node
    {
      public int NodeId { get; set; }
      public int LevelId { get; set; }
      public IEnumerable<Node> Children { get; set; }
      public override string ToString()
      {
        return String.Format("Node {0}, Level {1}", this.NodeId, this.LevelId);
      }
    }

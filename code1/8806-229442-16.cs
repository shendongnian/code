    [Test]
    public void Only_Return_Nodes_With_Even_Numbered_Node_IDs()
    {
      IEnumerable<Node> nodes = GetNodes();
      var flattenedNodes = nodes.Map(
        p => (p.NodeId % 2) == 0, 
        (Node n) => { return n.Children; }
      );
      foreach (Node flatNode in flattenedNodes)
      {
        Console.WriteLine(flatNode.ToString());
      }
      // Make sure we only end up with 3 nodes
      Assert.AreEqual(3, flattenedNodes.Count());
    }

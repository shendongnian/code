    [Test]
    public void Flatten_Nested_Heirachy()
    {
      IEnumerable<Node> nodes = GetNodes();
      var flattenedNodes = nodes.Map(
        p => true, 
        (Node n) => { return n.Children; }
      );
      foreach (Node flatNode in flattenedNodes)
      {
        Console.WriteLine(flatNode.ToString());
      }
      // Make sure we only end up with 6 nodes
      Assert.AreEqual(6, flattenedNodes.Count());
    }

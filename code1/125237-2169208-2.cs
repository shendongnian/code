    public IEnumerable<Node> Descendants
    {
       get
       {
          foreach (Node child in Children)
          {
             yield return child;
             foreach (Node descendant in child.Descendants)
             {
                yield return descendant;
             }
          }
       }
    }

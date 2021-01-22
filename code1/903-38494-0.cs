    public static class NodeExtensions {
      public INode GetParent( this INode node ) {
        // If the node implements the new interface, call it directly.
        var childNode = node as IChildNode;
        if( !object.ReferenceEquals( childNode, null ) )
          return childNode.Parent;
        
        // Otherwise, fall back on a default implementation.
        return FindParent( node, node.Root );
      }
    }

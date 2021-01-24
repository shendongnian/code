    public abstract class Node
    {
      WeakReference<Node> parent;
      public Node Root
      {
        get { return Parent?.Root; }
      }
      public Node Parent
      {
        get
        {
          if ( parent != null )
          {
            if ( parent.TryGetTarget( out Node parentNode ) )
            {
              return parentNode;
            }
          }
          return this;
        }
        internal set { /*...*/ } //--> if you're brave...
      }
    }

    public class NodeVisitor<T> : INodeVisitor where T : IContainer {
      public void VisitContainer(T node) {
        var container = node as T;
        if ( container != null ) { 
          VisitTyped(container);
        }
      }
      protected abstract VisitContainerTyped(T container);
    }

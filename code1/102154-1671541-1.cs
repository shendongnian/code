    public abstract class AbstractNode<T> //where T : AbstractNode
    {
      public abstract NodeCollection<T> ChildNodes
      {
        get;
        set;
      }
    }

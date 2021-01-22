    public class PARENT {
       private readonly IList<CHILD> _children = new List<CHILD>();
       public virtual Id { get; set; }
       public virtual void AddChild(CHILD child) {
          _children.add(child);
       }
    }
    public class CHILD {
       public virtual PARENT Parent { get; set; }
       public virtual Id { get; set; }
    }

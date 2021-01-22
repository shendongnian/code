    public class MyEntity
    {
       private readonly ISet<ChildEntity> children;
       
       public MyEntity()
       {
          children = new HashedSet<ChildEntity>();
       }
       
       public IEnumerable<ChildEntity> Children
       {
          get { return children; }
       }
    
       public void AddChild(Child child)
       {
         children.Add(child);
       }
    }

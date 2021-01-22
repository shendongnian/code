    public class ParentEntity {
      // This collection can be modified inside the class.
      List<ChildEntity> children = new List<ChildEntity>();
      ReadOnlyCollection<ChildEntity> readonlyChildren;
      public ReadOnlyCollection<ChildEntity> Children {
        get {
          return this.readOnlyChildren
            ?? (this.readOnlyChildren =
                  new ReadOnlyCollection<ChildEntity>(this.children));
        }
      }
    }
      

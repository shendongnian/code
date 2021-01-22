    public class MyClass {
    
      public MyClass Parent { get; private set; };
    
      private List<MyClass> _children;
    
      public ReadOnlyCollection<MyClass> Children {
        get { return _children.AsReadOnly(); }
      }
    
      public void AddChild(MyClass item) {
        item.Parent = this;
        _children.Add(item);
      }
    
      public void DeleteChild(MyClass item) {
        item.Parent = null;
        _children.Remove(item);
      }
    
    }

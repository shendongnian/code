    public class Parent {
      private List<Child> children;
      public ICollection<Child> Children { 
        get { return children.AsReadOnly(); } 
      }
      public void AddChild(Child child) {
        if (!child.IsSatisfiedBy(this)) throw new Exception();
        child.Parent = this;
        children.Add(child);
      }
    }
    public class Child {
      internal Parent Parent { get; set; }
      public DateTime ValidFrom;
      public DateTime ValidTo;
      public bool IsSatisfiedBy(Parent parent) { // can also be used before calling parent.AddChild
        return parent.Children.Any(c => Overlaps(c));
      }
      bool Overlaps(Child c) { 
        return 
          (c.ValidFrom > ValidFrom && c.ValidFrom < ValidTo) ||
          (c.ValidTo > ValidFrom && c.ValidTo < ValidTo) ||
          (c.ValidFrom <= ValidFrom && c.ValidTo >= ValidTo);
      }
    }

    public class Parent {
      List<Child> children = new List<Child>();
      ISpecification childValiditySpec;
      public Parent(ISpecification childValiditySpec) {
        this.childValiditySpec = childValiditySpec;
      }
      public ICollection<Child> Children {
        get { return children.AsReadOnly(); }
      }
      public bool IsSatisfiedBy(Child child) {
        return childValiditySpec.IsSatisfiedBy(this, child);
      }
      public void AddChild(Child child) {
        if (!IsSatisfiedBy(child)) throw new Exception();
        child.Parent = this;
        children.Add(child);
      }
    }

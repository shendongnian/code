    public interface IDependency
    {
    }
    
    public interface ConcreteDependency1 : IDependency
    {
    }
   
    public class Base
    {
      protected Base(IDependency dependency)
      {
        MyDependency = dependency;
      }
      protected IDependency MyDependency {get; private set;}
    }
    public class Derived1 : Base // Derived1 depends on ConcreteDependency1
    {
      public Derived1(ConcreteDependency1 dependency)  : base(dependency) {}
      // the new keyword allows to define a property in the derived class
      // that casts the base type to the correct concrete type
      private new ConcreteDependency1 MyDependency {get {return (ConcreteDependency1)base.MyDependency;}}
    }

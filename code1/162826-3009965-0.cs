    public class BaseClass
    {
      public string MyString  { get; set; }
      public virtual string DoIt()
      {
        return "I'm Base Class";
      }
    }
    public class DerivedClassA
    {
      public override string DoIt()
      {
        return "I'm Derived Class A";
      }
    }
    public class DerivedClassB
    {
      public override string DoIt()
      {
        return "I'm Derived Class B";
      }
    }
    ....
    public ClassA (BaseClass myClass)
    {
        MyClass = myClass;
        MyClass.DoIt(); 
    }
    .....
    ClassA x1 = ClassA(new BaseClass()) // calls BaseClass.DoIt()
    ClassA x2 = ClassA(new DerivedClassA()) // calls DerivedClassA.DoIt()
    ClassA x3 = ClassA(new DerivedClassB()) // calls DerivedClassB.DoIt()

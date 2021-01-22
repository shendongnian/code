    public class Person 
    { 
      public virtual int Id { get; set; } 
      public virtual string Name { get; set; } 
    } 
    public class PersonDerived : Person
    {
      public override int Id { get { ... } set { ... } }
      public override string Name { get { ... } set { ... } }
    }

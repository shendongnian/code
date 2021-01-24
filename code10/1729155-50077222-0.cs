    abstract class MyBaseClass {
    
       [Attribute1]
       [Attribute2]
       public virtual string Property1 {get; set; }
    
       [Attribute3]
       [Attribute4]
       public virtual string Property2 {get; set; }
    }
    
    class NewClass:MyBaseClass
    {
      [Attribute5]
      public override string Property1 {get;set;}
    
      [Attribute6]
      public override string Property2 {get;set;}
    }

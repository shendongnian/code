    abstract class MyBaseClass {
    
       [Obsolete]
       public virtual string Property1 {get; set; }
    
    }
    
    class Derived : MyBaseClass
    {
    	public override string Property1 {get; set;}
    }

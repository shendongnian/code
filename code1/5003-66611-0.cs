    abstract class:
    
    private const string nameConstant = "ABSTRACT";
    
    public string Name
    {
       get {return this.GetName();}
    }
    
    protected virtual string GetName()
    {
       return MyAbstractClass.nameConstant;
    }
    
    ----
    
    class ChildClass : MyAbstractClass
    {
       private const string nameConstant = "ChildClass";
    
       protected override string GetName()
       {
          return ChildClass.nameConstant;
       }
    }

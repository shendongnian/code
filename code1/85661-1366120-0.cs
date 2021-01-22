    abstract class SomeBaseClass
    {
    
       public void DoSomething()
       {
           ...
           somethingElse();
           ...
       }
    
       abstract void somethingElse();
    
    }
    
    public class CompanyA : SomeBaseClass
    {
        void somethingElse()
        {
           // do something specific
        }
    }
    
    public class CompanyB : SomeBaseClass
    {
        void somethingElse()
        {
           // do something specific
        }
    }

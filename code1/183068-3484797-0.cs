    public class Foo 
    { 
       private readonly List<string> strs = new List<string>(); 
     
       public Foo()
       {
           // strs is readonly, so we can assign it here but nowhere else
           strs = ResultOfSomeFunction();
       }
       public void DoSomething() 
       { 
           // Compiler warning from the static checker: 
           // "requires unproven: source != null" 
           strs.Add("hello"); 
       } 
    }

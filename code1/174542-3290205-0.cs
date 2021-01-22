    //other usings...
    //Extension using statement...
    using MyAssembly.Extensions;
    
    class Program {
      static void Main() {
        //some code
        String myString = "blah";
    
        //call the extension method now
        String newString = myString.MyExtensionMethod();
      }
    }

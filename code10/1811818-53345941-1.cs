    using System;
    using MyClass; //get your other file by the namespace
    namespace MyActivity {
       
       public static class Program {
         
         public static void OnSuccess()
         {
             Program.MyMethod();  //[class name]..MyMethod();
         }
       }
    }

    using System;
    using System.Collections.Generic;
    using System.Reflection;
    namespace ConsoleApplication2 {
     class Program {
       class Person {}
       static void Main(){
           Assembly myAssembly = typeof(Program).Assembly;
           Type passInType = myAssembly.GetType(
               "ConsoleApplication2.Program+Person");
           Type t = typeof(List<>).MakeGenericType(passInType);
       }
     }
    }

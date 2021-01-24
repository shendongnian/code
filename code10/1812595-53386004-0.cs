    ../MyFolder/A.dll
         public class MyType;
         public class MyAnotherType;
         ....
     var aDll = Assembly.LoadFile("A.dll");
     var aDllAgain = Assembly.LoadFile("A.dll");
     var myTypeFromADll =aDll.GetType("MyType");
     var myTypeFromADllAgain = aDllAgain.GetType("MyType");
     //Yes this is of type MyType but since you used LoadFile
     //It is of type MyType from a_dll code base
     var instanceFromADll = Activator.CreateInstance(myTypeFromADll);
     //Yes this is of type MyType but since you used LoadFile
     //It is of type MyType from a_dll_again code base
     var instanceFromADllAgain = Activator.CreateInstance(myTypeFromADllAgain);

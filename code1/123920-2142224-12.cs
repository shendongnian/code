    using System;
    using System.IO;
    using System.Reflection;
    using IronPython.Hosting;
    using Microsoft.Scripting.Hosting;
    // we get access to Action and Func on .Net 2.0 through Microsoft.Scripting.Utils
    using Microsoft.Scripting.Utils;
    
    
    namespace TestCallIronPython
    {
        class Program
        {
            public static void Main(string[] args)
            {
                Console.WriteLine("Hello World!");
                ScriptEngine pyEngine = Python.CreateEngine();
    
                Assembly myclass = Assembly.LoadFile(Path.GetFullPath("MyClass.dll"));
                pyEngine.Runtime.LoadAssembly(myclass);
                ScriptScope pyScope = pyEngine.Runtime.ImportModule("MyClass");
    
                // Get the Python Class
                object MyClass = pyEngine.Operations.Invoke(pyScope.GetVariable("MyClass"));
    
                // Invoke a method of the class
                pyEngine.Operations.InvokeMember(MyClass, "somemethod", new object[0]);
    
                // create a callable function to 'somemethod'
                Action SomeMethod2 = pyEngine.Operations.GetMember<Action>(MyClass, "somemethod");
                SomeMethod2();
                
                // create a callable function to 'isodd'
                Func<int, bool> IsOdd = pyEngine.Operations.GetMember<Func<int, bool>>(MyClass, "isodd");
                Console.WriteLine(IsOdd(1).ToString());
                Console.WriteLine(IsOdd(2).ToString());
                
                Console.Write("Press any key to continue . . . ");
                Console.ReadKey(true);
            }
        }
    }

    using System;
    using System.Text;
    using IronPython.Hosting;
    using IronPython.Runtime;
    using Microsoft.Scripting;
    using Microsoft.Scripting.Hosting;
    
    namespace TestCallIronPython
    {
        class Program
        {
            public static void Main(string[] args)
            {
                Console.WriteLine("Hello World!");
                ScriptEngine pyEngine = null;
                ScriptScope pyScope = null;
    
                pyEngine = Python.CreateEngine();
                pyScope = pyEngine.CreateScope();
                pyScope.SetVariable("test", "test variable");
                
                string code = @"
    import clr
    clr.AddReference('MyClass')
    from MyClass import MyClass
    ";
                
                ScriptSource source = pyEngine.CreateScriptSourceFromString(code);
                CompiledCode compiled = source.Compile();
                compiled.Execute(pyScope);
                
                //Invoke a python method
                object pyobject = pyEngine.Operations.Invoke(pyScope.GetVariable("MyClass"));
                pyEngine.Operations.InvokeMember(pyobject, "somemethod", new object[0]);
               
                Console.Write("Press any key to continue . . . ");
                Console.ReadKey(true);
            }
        }
    }

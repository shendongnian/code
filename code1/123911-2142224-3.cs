    using System;
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
                
                string pyprogram = @"
    import sys
    import clr
    clr.AddReference('MyClass')
    from MyClass import MyClass
    m = MyClass()
    print 'And Hello World from IronPython'
    ";
                
                RunIt(pyEngine, pyScope, pyprogram);
               
                Console.Write("Press any key to continue . . . ");
                Console.ReadKey(true);
            }
            
            static void RunIt(ScriptEngine pyEngine, ScriptScope pyScope, string code)
            {
                ScriptSource source = pyEngine.CreateScriptSourceFromString(code);
                CompiledCode compiled = source.Compile();
                compiled.Execute(pyScope);
            }
        }
    }

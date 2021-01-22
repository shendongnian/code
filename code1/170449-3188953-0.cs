    using (Microsoft.CSharp.CSharpCodeProvider foo = 
               new Microsoft.CSharp.CSharpCodeProvider())
    {
        var res = foo.CompileAssemblyFromSource(
            new System.CodeDom.Compiler.CompilerParameters() 
            {  
                GenerateInMemory = true 
            }, 
            "public class FooClass { public string Execute() { return \"output!\";}}"
        );
        var type = res.CompiledAssembly.GetType("FooClass");
        var obj = Activator.CreateInstance(type);
        var output = type.GetMethod("Execute").Invoke(obj, new object[] { });
    }

    private bool Eval(object item, string name, string op, string value)
    {
        
        var foo = new Microsoft.CSharp.CSharpCodeProvider()
            .CompileAssemblyFromSource(
                new CompilerParameters(), 
                new[] { "public class Foo { public static bool Eval("+ 
                    item.GetType().FullName +" t) "+
                   "{ return t."+ name +" "+ op +" "+ value +"; } }"   
                }).CompiledAssembly.GetType("Foo");
        return (bool)foo.InvokeMember("Eval",
            BindingFlags.Static | BindingFlags.Public | BindingFlags.InvokeMethod ,
            null, null, new object[] { item });
    }

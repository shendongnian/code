    private Func<T,bool> Make<T>(string name, string op, string value)
    {
        
        var foo = new Microsoft.CSharp.CSharpCodeProvider()
            .CompileAssemblyFromSource(
                new CompilerParameters(), 
                new[] { "public class Foo { public static bool Eval("+ 
                    typeof(T).FullName +" t) { return t."+ 
                    name +" "+ op +" "+ value 
                    +"; } }" }).CompiledAssembly.GetType("Foo");
    	return t => (bool)foo.InvokeMember("Eval",
            BindingFlags.Static | BindingFlags.Public | BindingFlags.InvokeMethod ,
            null, null, new object[] { t });
    }
    
    // use like so:
    var f =  Make<string>("Length", ">", "2");

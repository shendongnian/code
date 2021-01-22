    var cr = new CSharpCodeProvider().CompileAssemblyFromSource(
    	new CompilerParameters { GenerateInMemory = true }, 
    	"class x { public static string e() { return " + input + "}}");
    
    var result = cr.CompiledAssembly.GetType("x")
    	.GetMethod("e").Invoke(null, null) as string;

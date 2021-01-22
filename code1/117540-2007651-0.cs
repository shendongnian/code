    var csc = new CSharpCodeProvider().CreateCompiler();
    
    var source = new StringBuilder();
    source.Append("namespace x { public class y {");
    source.Append("public static string eval() { return ");
    source.Append(input);  // your source string
    source.Append("}}}");
    
    var cr = csc.CompileAssemblyFromSource(
    	new CompilerParameters { GenerateInMemory = true }, source.ToString());
    		
    var result = cr.CompiledAssembly.GetType("x.y")
    	.GetMethod("eval").Invoke(null, null) as string;

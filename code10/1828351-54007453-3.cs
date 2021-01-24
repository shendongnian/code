    string source = @"using System;
    namespace program {
        public class TestPerson
        {
            public static void Main()
            {
                Console.WriteLine(""TEST"");
            }
        }
    }";
    
    void Main()
    {
    	Dictionary<string, string> providerOptions = new Dictionary<string, string>
    			{
    				{"CompilerVersion", "v4.0"}
    			};
    	CSharpCodeProvider provider = new CSharpCodeProvider(providerOptions);
    
    	CompilerParameters compilerParams = new CompilerParameters
    	{
    		GenerateInMemory = true,
    		GenerateExecutable = false,
    		ReferencedAssemblies = { "System.dll", "mscorlib.dll" }
    	};
    	CompilerResults results = provider.CompileAssemblyFromSource(compilerParams, source);
    	Assembly assembly = results.CompiledAssembly;
    	Type program = assembly.GetType("program.TestPerson");
    	MethodInfo main = program.GetMethod("Main");
    	
    	var sb = new StringBuilder();
    	var writer = new StringWriter(sb);
    	Console.SetOut(writer);
    	
    	var outp = main.Invoke(null, null);
    
    	sb.ToString().Dump(); // this Dump is from linqpad, do what you want with the StringBuilder content 
    
    	Console.ReadLine();
     }

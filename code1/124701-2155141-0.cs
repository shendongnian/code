    List<string> referenceAssemblies = new List<string>()
    {
        "System.dll"
        // ...
    };
    
    string source = "public abstract class TestClass {" + input + ";}";
    
    CSharpCodeProvider codeProvider = new CSharpCodeProvider();
    
    // No assembly name specified
    CompilerParameters compilerParameters =
        new CompilerParameters(referenceAssemblies.ToArray());
    compilerParameters.GenerateExecutable = false;
    compilerParameters.GenerateInMemory = false;
    
    CompilerResults compilerResults = codeProvider.CompileAssemblyFromSource(
        compilerParameters, source);
    // Check for successful compilation here
    Type testClass = compilerResults.CompiledAssembly.GetTypes().First();

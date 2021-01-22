    var codeProvider = new Microsoft.CSharp.CSharpCodeProvider(
    new Dictionary<string, string> { { "CompilerVersion", "v4.0" } });
    var parameters = new System.CodeDom.Compiler.CompilerParameters 
    {
        GenerateInMemory = true,
        GenerateExecutable = false,
        IncludeDebugInformation = true,
        TreatWarningsAsErrors = false
    };
    // Here add more referenced assemblies
    parameters.ReferencedAssemblies.Add("Microsoft.CSharp.dll");

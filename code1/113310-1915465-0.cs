    string getTypeHack = @"using System; public static class TypeHacker {{ public static Type GetThisType() {{ return typeof({0}); }} }}";
    
    CodeDomProvider codeProvider = CodeDomProvider.CreateProvider("CSharp");
    CompilerParameters parameters = new CompilerParameters();
    parameters.GenerateInMemory = true;
    parameters.GenerateExecutable = false;
    CompilerResults results = codeProvider.CompileAssemblyFromSource(parameters, string.Format(getTypeHack, "int"));
    
    Type hacker = results.CompiledAssembly.GetType("TypeHacker");
    MethodInfo hack = hacker.GetMethod("GetThisType");
    Type actualType = (Type)hack.Invoke(null, null);

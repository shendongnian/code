    CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
    CompilerParameters cs = new CompilerParameters();
    cp.GenerateInMemory = True;
    
    CompilerResult result = provider.CompileAssemblyFromSource(cp, enumSourceCode);
    
    Type enumType = result.CompiledAssembly.GetType(enumName);

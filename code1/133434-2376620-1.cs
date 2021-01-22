    var cp = new System.CodeDom.Compiler.CompilerParameters {
      ReferencedAssemblies.Add(filesystemLocation), // like /R: option on csc.exe
      GenerateInMemory = true,    // you will get a System.Reflection.Assembly back
      GenerateExecutable = false, // Dll
      IncludeDebugInformation = false,
      CompilerOptions = ""
    };
    var csharp = new Microsoft.CSharp.CSharpCodeProvider();
    // this actually runs csc.exe:
    System.CodeDom.Compiler.CompilerResults cr = 
          csharp.CompileAssemblyFromSource(cp, LiteralSource);
    // cr.Output contains the output from the command
    if (cr.Errors.Count != 0)
    {
        // handle errors
    }
    System.Reflection.Assembly a = cr.CompiledAssembly;
    // party on the type here, either via reflection...
    System.Type t = a.GetType("TheDynamicallyGeneratedType");
    // or via a wellknown interface

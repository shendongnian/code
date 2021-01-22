    public static Type[] DynamicTypes;
    public void CreateObjects()
    {
      var codeNamespace = new CodeNamespace( "DynamicClasses" );
      codeNamespace.Imports.Add( new CodeNamespaceImport( "System" ) );
      codeNamespace.Imports.Add( new CodeNamespaceImport( "System.ComponentModel" ) );
      for( var i = 0; i < 2000; i++ )
      {
        var classToCreate = new CodeTypeDeclaration( "DynamicClass_" + i )
        {
          TypeAttributes = TypeAttributes.Public
        };
        var codeConstructor1 = new CodeConstructor
        {
          Attributes = MemberAttributes.Public
        };
        classToCreate.Members.Add( codeConstructor1 );
        codeNamespace.Types.Add( classToCreate );
      }
      var codeCompileUnit = new CodeCompileUnit();
      codeCompileUnit.Namespaces.Add( codeNamespace );
      var compilerParameters = new CompilerParameters
      {
        GenerateInMemory = true,
        IncludeDebugInformation = true,
        TreatWarningsAsErrors = true,
        WarningLevel = 4
      };
      compilerParameters.ReferencedAssemblies.Add( "System.dll" );
      var compilerResults = new CSharpCodeProvider().CompileAssemblyFromDom( compilerParameters, codeCompileUnit );
      if( compilerResults == null )
      {
        throw new InvalidOperationException( "ClassCompiler did not return results." );
      }
      if( compilerResults.Errors.HasErrors )
      {
        var errors = string.Empty;
        foreach( CompilerError compilerError in compilerResults.Errors )
        {
          errors += compilerError.ErrorText + "\n";
        }
        Debug.Fail( errors );
        throw new InvalidOperationException( "Errors while compiling the dynamic classes:\n" + errors );
      }
      var dynamicAssembly = compilerResults.CompiledAssembly;
      DynamicTypes = dynamicAssembly.GetExportedTypes();
    }

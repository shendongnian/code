    private static Type GetTypeByFullNameOrAlias(string typeName)
    {
      Type type = Type.GetType(typeName);
      if (type == null)
      {
        using (var provider = new CSharpCodeProvider())
        {
          var compiler = provider.CompileAssemblyFromSource(
            new CompilerParameters
              {GenerateInMemory = true, GenerateExecutable = false, IncludeDebugInformation = false},
            "public class A { public " + typeName + " B; }");
          type = ((FieldInfo)compiler.CompiledAssembly.GetType("A").GetMember("B")[0]).FieldType;
        }
      }
      return type;
    }

     private static Assembly CompileSourceCodeDom(string sourceCode)
     {
         CodeDomProvider cpd = new CSharpCodeProvider();
         var cp = new CompilerParameters();
         cp.ReferencedAssemblies.Add("System.dll");
         cp.GenerateExecutable = false;
         CompilerResults cr = cpd.CompileAssemblyFromSource(cp, sourceCode);
         return cr.CompiledAssembly;
    }
    private static void ExecuteFromAssembly(Assembly assembly)
    {
        Type fooType = assembly.GetType("Foo");
        MethodInfo printMethod = fooType.GetMethod("Print");
        object foo = assembly.CreateInstance("Foo");
        printMethod.Invoke(foo, BindingFlags.InvokeMethod, null, null, CultureInfo.CurrentCulture);
    }

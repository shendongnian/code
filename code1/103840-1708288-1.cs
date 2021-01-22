    string source = <Code from above>;
    Assembly a;
    using (CSharpCodeProvider provider = new CSharpCodeProvider(...) {
        List<string> assemblies = new List<string>();
        foreach (Assembly x in AppDomain.CurrentDomain.GetAssemblies()) {
            try {
                assemblies.Add(x.Location);
            }
            catch (NotSupportedException) {
                // Dynamic assemblies will throw, and in .net 3.5 there seems to be no way of finding out whether the assembly is dynamic before trying.
            }
        }
					
        CompilerResults r = provider.CompileAssemblyFromSource(new CompilerParameters(assemblies.ToArray()) { GenerateExecutable = false, GenerateInMemory = true }, source);
        if (r.Errors.HasErrors)
            throw new Exception("Errors compiling expression: " + string.Join(Environment.NewLine, r.Errors.OfType<CompilerError>().Select(e => e.ErrorText).ToArray()));
        a = r.CompiledAssembly;
    }
    object o = a.CreateInstance("ExpressionContainer");
    var result = ( Expression<Func<Product, bool>>)o.GetType().GetProperty("TheExpression").GetValue(o);

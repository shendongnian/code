    static readonly Assembly[] References = new[] { typeof(Enumerable).Assembly, typeof(Component).Assembly };
    public Action CompileMacro(string source) {
        var options = new CompilerParameters(References.Select(a => a.Location).ToArray()) {
            GenerateInMemory = true
        };
        string fullSource = @"public static class MacroHolder { public static void Execute() { \r\n" + source + "\r\n} }";
        try {
            var compiler = new CSharpCodeProvider(new Dictionary<string, string> { { "CompilerVersion", "v4.0" } });
            var results = compiler.CompileAssemblyFromSource(options, fullSource);
            if (results.Errors.Count > 0)
                throw new InvalidOperationException(String.Join(
                    Environment.NewLine, 
                    results.Errors.Cast<CompilerError>().Select(ce => ce.ErrorText)
                ));
            return (Action)Delegate.CreateDelegate(
                typeof(Action),
                results.CompiledAssembly.GetType("MacroHolder").GetMethod("Execute")
            );
        } finally { options.TempFiles.Delete(); }
    }

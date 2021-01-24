    var expression = "System.Console.WriteLine(\"Test\")";
    var origTree = CSharpSyntaxTree.ParseText(expression, 
                      CSharpParseOptions.Default.WithKind(SourceCodeKind.Script));
    var root = origTree.GetRoot();
    // -Snip- tree manipulation
    var script = CSharpScript.Create(otherRoot.ToString());
    var errors = script.Compile();
    if(errors.Any(x => x.Severity == DiagnosticSeverity.Error)) {
    	throw new Exception($"Compilation errors:\n{string.Join("\n", errors.Select(x => x.GetMessage()))}");
    }
    await script.RunAsync();
    await script.RunAsync();

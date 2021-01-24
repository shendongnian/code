    public Assembly CreateAssembly(string code)
    {
    	var encoding = Encoding.UTF8;
    
    	var assemblyName = Path.GetRandomFileName();
    	var symbolsName = Path.ChangeExtension(assemblyName, "pdb");
    	var sourceCodePath = "generated.cs";
    
    	var buffer = encoding.GetBytes(code);
    	var sourceText = SourceText.From(buffer, buffer.Length, encoding, canBeEmbedded: true);
    
    	var syntaxTree = CSharpSyntaxTree.ParseText(
    		sourceText, 
    		new CSharpParseOptions(), 
    		path: sourceCodePath);
    
    	var syntaxRootNode = syntaxTree.GetRoot() as CSharpSyntaxNode;
    	var encoded = CSharpSyntaxTree.Create(syntaxRootNode, null, sourceCodePath, encoding);
    
    	var optimizationLevel = OptimizationLevel.Debug;
    
    	CSharpCompilation compilation = CSharpCompilation.Create(
    		assemblyName,
    		syntaxTrees: new[] { encoded },
    		references: references,
    		options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary)
    			.WithOptimizationLevel(optimizationLevel)
    			.WithPlatform(Platform.AnyCpu)
    	);
    
    	using (var assemblyStream = new MemoryStream())
    	using (var symbolsStream = new MemoryStream())
    	{
    		var emitOptions = new EmitOptions(
    				debugInformationFormat: DebugInformationFormat.PortablePdb,
    				pdbFilePath: symbolsName);
    
    		var embeddedTexts = new List<EmbeddedText>
    		{
    			EmbeddedText.FromSource(sourceCodePath, sourceText),
    		};
    
    		EmitResult result = compilation.Emit(
    			peStream: assemblyStream,
    			pdbStream: symbolsStream,
    			embeddedTexts: embeddedTexts,
    			options: emitOptions);
    
    		if (!result.Success)
    		{
    			var errors = new List<string>();
    
    			IEnumerable<Diagnostic> failures = result.Diagnostics.Where(diagnostic =>
    				diagnostic.IsWarningAsError ||
    				diagnostic.Severity == DiagnosticSeverity.Error);
    
    			foreach (Diagnostic diagnostic in failures)
    				errors.Add($"{diagnostic.Id}: {diagnostic.GetMessage()}");
    
    			throw new Exception(String.Join("\n", errors));
    		}
    
    		Console.WriteLine(code);
    
    		assemblyStream.Seek(0, SeekOrigin.Begin);
    		symbolsStream?.Seek(0, SeekOrigin.Begin);
    
    		var assembly = AssemblyLoadContext.Default.LoadFromStream(assemblyStream, symbolsStream);
    		return assembly;
    	}
    }

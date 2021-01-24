    CSharpParseOptions options = CSharpParseOptions.Default
		.WithFeatures(new[] { new KeyValuePair<string, string>("flow-analysis", "")     
    });
	MSBuildWorkspace workspace = MSBuildWorkspace.Create();
	Solution solution = workspace.OpenSolutionAsync(solutionUrl).Result; // path to your SLN file
	ProjectDependencyGraph projectGraph = solution.GetProjectDependencyGraph();
	Dictionary<string, Stream> assemblies = new Dictionary<string, Stream>();
	var projects = projectGraph.GetTopologicallySortedProjects().ToDictionary(
		p => p,
		p => solution.GetProject(p).Name);
	var bllProjectId = projects.First(p => p.Value == "<your project name>").Key; // choose project for analysis
	var projectId = bllProjectId;
	solution = solution.WithProjectParseOptions(projectId, options);
	Compilation compilation = solution.GetProject(projectId).GetCompilationAsync().Result;
	if (compilation != null && !string.IsNullOrEmpty(compilation.AssemblyName))
	{
		var syntaxTree = compilation.SyntaxTrees.First();
        // get syntax nodes for methods
		var methodNodes = from methodDeclaration in syntaxTree.GetRoot().DescendantNodes()
				.Where(x => x is MethodDeclarationSyntax)
			select methodDeclaration;
		foreach (MethodDeclarationSyntax node in methodNodes)
		{
			var model = compilation.GetSemanticModel(node.SyntaxTree);
			node.Identifier.ToString().Dump();
			if (node.SyntaxTree.Options.Features.Any())
			{
				var graph = ControlFlowGraph.Create(node, model); // CFG is here
			}
			else
			{
				// "No features".Dump();
			}
		}
	}

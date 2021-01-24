    static async Task<Solution> MergePartialClasses(string targetClass, Solution solution)
    {
        // https://stackoverflow.com/a/32179708/276994
        // we loop through the projects in the solution and process each of the projects
        foreach (var projectId in solution.ProjectIds)
        {
            var project = solution.GetProject(projectId);
            WriteLine($"Processing project {project.Name}");
            var compilation = await project.GetCompilationAsync();
            // finding the type which we want to merge
            var type = compilation.GetTypeByMetadataName(targetClass);
            if (type == null)
            {
                WriteLine($"Type {targetClass} is not found");
                return solution;
            }
            // look up number of declarations. if it's only 1, we have nothing to merge
            var declarationRefs = type.DeclaringSyntaxReferences;
            if (declarationRefs.Length <= 1)
            {
                WriteLine($"Type {targetClass} has only one location");
                return solution;
            }
            // I didn't implement the case of nested types, which would require to
            // split the outer class, too
            if (type.ContainingType != null)
                throw new NotImplementedException("Splitting nested types");
            // we'll accumulate usings and class members as we traverse all the definitions
            var accumulatedUsings = new List<UsingDirectiveSyntax>();
            var classParts = new List<ClassDeclarationSyntax>();
            foreach (var declarationRef in declarationRefs)
            {
                var declaration = (ClassDeclarationSyntax)await declarationRef.GetSyntaxAsync();
                // get hold of the usings
                var tree = declaration.SyntaxTree;
                var root = await tree.GetRootAsync();
                var usings = root.DescendantNodes().OfType<UsingDirectiveSyntax>();
                accumulatedUsings.AddRange(usings);
                // since we are trying to move the syntax into another file,
                // we need to expand everything in order to remove the dependency
                // on usings
                // in order to do it, we use a custom CSharpSyntaxRewriter (defined later)
                var document = project.GetDocument(tree);
                var expander = new AllSymbolsExpander(document);
                var expandedDeclaration = (ClassDeclarationSyntax)expander.Visit(declaration);
                classParts.Add(expandedDeclaration);
                // remove the old declaration from the place where it is
                // we can't just remove the whole file as it may contain some other classes
                var modifiedRoot =
                    root.RemoveNodes(new[] { declaration }, SyntaxRemoveOptions.KeepNoTrivia);
                var modifiedDocument = document.WithSyntaxRoot(modifiedRoot);
                project = modifiedDocument.Project;
            }
            // now, sort the usings and remove the duplicates
            // in order to use DistinctBy, I added MoreLinq nuget package and added
            // using MoreLinq; at the beginning
            // https://stackoverflow.com/a/34063289/276994
            var sortedUsings = accumulatedUsings
                    .DistinctBy(x => x.Name.ToString())
                    .OrderBy(x => x.StaticKeyword.IsKind(SyntaxKind.StaticKeyword) ?
                                      1 : x.Alias == null ? 0 : 2)
                    .ThenBy(x => x.Alias?.ToString())
                    .ThenByDescending(x => x.Name.ToString().StartsWith(nameof(System) + "."))
                    .ThenBy(x => x.Name.ToString());
            // now, we have to merge the class definitions.
            // split the name into namespace and class name
            var (nsName, className) = SplitName(targetClass);
            // gather all the attributes
            var attributeLists = List(classParts.SelectMany(p => p.AttributeLists));
            // modifiers must be the same, so we are taking them from the
            // first definition, but remove partial if it's there
            var modifiers = classParts[0].Modifiers;
            var partialModifier = modifiers.FirstOrDefault(
                    m => m.Kind() == SyntaxKind.PartialKeyword);
            if (partialModifier != null)
                modifiers = modifiers.Remove(partialModifier);
            // gather all the base types
            var baseTypes =
                    classParts
                        .SelectMany(p => p.BaseList?.Types ?? Enumerable.Empty<BaseTypeSyntax>())
                        .Distinct()
                        .ToList();
            var baseList = baseTypes.Count > 0 ? BaseList(SeparatedList(baseTypes)) : null;
            // and constraints (I hope that Distinct() works as expected)
            var constraintClauses =
                    List(classParts.SelectMany(p => p.ConstraintClauses).Distinct());
            // now, we construct class members by pasting together the accumulated
            // per-part member lists
            var members = List(classParts.SelectMany(p => p.Members));
            // now we can build the class declaration
            var classDef = ClassDeclaration(
                attributeLists: attributeLists,
                modifiers: modifiers,
                identifier: Identifier(className),
                typeParameterList: classParts[0].TypeParameterList,
                baseList: baseList,
                constraintClauses: constraintClauses,
                members: members);
            // if there was a namespace, let's put the class inside it 
            var body = (nsName == null) ?
                (MemberDeclarationSyntax)classDef :
                NamespaceDeclaration(IdentifierName(nsName)).AddMembers(classDef);
            // now create the compilation unit and insert it into the project
            // http://roslynquoter.azurewebsites.net/
            var newTree = CompilationUnit()
                              .WithUsings(List(sortedUsings))
                              .AddMembers(body)
                              .NormalizeWhitespace();
            var newDocument = project.AddDocument(className, newTree);
            var simplifiedNewDocument = await Simplifier.ReduceAsync(newDocument);
            project = simplifiedNewDocument.Project;
            solution = project.Solution;
        }
        // finally, return the modified solution
        return solution;
    }

    foreach (var diagnostic in diagnostics)
    {
         servicesProject = solution.GetProject(servicesId);
         var errorLineSpan = diagnostic.Location.GetLineSpan();
         var document = servicesProject.FindDocumentByName(Path.GetFileName(errorLineSpan.Path));
         var syntaxTree = await document.GetSyntaxTreeAsync();
         var errorSpan = errorLineSpan.Span;
         var lineSpan = syntaxTree.GetText().Lines[errorSpan.Start.Line].Span;
         var node = syntaxTree.GetRoot().DescendantNodes(lineSpan)
    .First(n => lineSpan.Contains(n.FullSpan)).DescendantNodes()
    .OfType<IdentifierNameSyntax>().FirstOrDefault(c => c.Identifier.Text == oldValue);
            var newNode = node.ReplaceNode(node, SyntaxFactory.IdentifierName(newValue));
            var newSyntaxRoot = syntaxTree.GetRoot().ReplaceNode(node, newNode);
            document = document.WithSyntaxRoot(newSyntaxRoot);
            solution = document.Project.Solution;           
    }

    // collect usings
    SyntaxList<UsingDirectiveSyntax> allUsings = SyntaxFactory.List<UsingDirectiveSyntax>();
    foreach (var syntaxRef in ClassSymbol.DeclaringSyntaxReferences)
    {
        foreach (var parent in syntaxRef.GetSyntax().Ancestors(false))
        {
            if (parent is NamespaceDeclarationSyntax)
                allUsings = allUsings.AddRange(((NamespaceDeclarationSyntax)parent).Usings);
            else if (parent is CompilationUnitSyntax)
                allUsings = allUsings.AddRange(((CompilationUnitSyntax)parent).Usings);
        }
    }

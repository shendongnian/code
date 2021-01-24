    var localDeclaration = new LocalDeclarationVirtualizationVisitor();
    localDeclaration.Visit(root);
    var localDeclarations = localDeclaration.LocalDeclarations;
    foreach (var localDeclarationStatementSyntax in localDeclarations)
    {
        foreach (VariableDeclaratorSyntax variable in localDeclarationStatementSyntax.Declaration.Variables)
        {
            var stringKind = variable.Initializer.Value.Kind();
            if (stringKind == SyntaxKind.StringLiteralExpression)
            {                       
                Console.WriteLine($"Key: {variable.Identifier.Value} Value:{variable.Initializer.Value}");
            }
        }
    }

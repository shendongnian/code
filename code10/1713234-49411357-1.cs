    foreach (var localDeclarationStatementSyntax in localDeclarations)
    {
        foreach (VariableDeclaratorSyntax variable in localDeclarationStatementSyntax.Declaration.Variables)
        {
    
            var stringKind = variable.Initializer.Value.Kind();
    
            if (stringKind == SyntaxKind.StringLiteralExpression)
            {
                var newVariable = SyntaxFactory.ParseStatement($"string {variable.Identifier.ValueText} = StringManipulation({variable.Initializer.Value});");
                newVariable.NormalizeWhitespace();
    
                editor.ReplaceNode(variable, newVariable);
    
                Console.WriteLine($"Key: {variable.Identifier.Value} Value:{variable.Initializer.Value}");
            }
        }
    }

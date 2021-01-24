    var statements = new List<StatementSyntax>();
    var methodDeclarations = root.DescendantNodes().OfType<MethodDeclarationSyntax>();
    foreach (var memmeth in methodDeclarations)
    {
        var varInvocations = memmeth.DescendantNodes().OfType<InvocationExpressionSyntax>();
        foreach (InvocationExpressionSyntax invoc in varInvocations)
        {
            // Find the relevant node
            var statement = invoc.Ancestors().OfType<StatementSyntax>().FirstOrDefault();
            statements.Add(statement);
        }
    }
    // Track the nodes so you can change it in the tree even after modifying it
    root = root.TrackNodes(statements.Distinct());
    foreach(var statement in statements)
    {
        var currentStatement = root.GetCurrentNode(statement);
        root = root.InsertNodesAfter(currentStatement,            
            new[] { SyntaxFactory.ExpressionStatement(
                        SyntaxFactory.InvocationExpression(
                            SyntaxFactory.MemberAccessExpression(
                                SyntaxKind.SimpleMemberAccessExpression, 
                                SyntaxFactory.IdentifierName("Console"), 
                                SyntaxFactory.IdentifierName("WriteLine"))
                            ))});
        currentStatement = root.GetCurrentNode(statement);
        root = root.InsertNodesBefore(currentStatement,
            new[] { SyntaxFactory.ExpressionStatement(
                SyntaxFactory.InvocationExpression(
                    SyntaxFactory.MemberAccessExpression(
                        SyntaxKind.SimpleMemberAccessExpression,
                        SyntaxFactory.IdentifierName("Console"),
                        SyntaxFactory.IdentifierName("WriteLine"))
                    ))});
    }

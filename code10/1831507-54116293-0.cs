    private async Task<Document> ProvideCodeFix(Document document, InvocationExpressionSyntax invocationExpression, CancellationToken cancellationToken)
    {
        // Get the expression that represents the entity that the invocation happens on
        // (In this case this is the method name including possible class name, namespace, etc)
        var invokedExpression = invocationExpression.Expression;
        // Construct an expression for the new classname and methodname
        var classNameSyntax = SyntaxFactory.IdentifierName("SecondClass");
        var methodNameSyntax = SyntaxFactory.IdentifierName("ReplaceDoSomething");
        var classNameAndMethodNameSyntax = SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, classNameSyntax, methodNameSyntax);
        // Add the surrounding trivia from the original expression
        var replaced = classNameAndMethodNameSyntax;
        replaced = replaced.WithLeadingTrivia(invokedExpression.GetLeadingTrivia());
        replaced = replaced.WithTrailingTrivia(invokedExpression.GetTrailingTrivia());
        // Replace the whole original expression with the new expression
        return document.WithSyntaxRoot((await document.GetSyntaxRootAsync()).ReplaceNode(invokedExpression, replaced));
    }

    foreach (var invocationExpressionSyntax in invocationExpressions)
    {
        if (invocationExpressionSyntax.ArgumentList.Arguments.Any(x =>
            x.Expression.Kind() == SyntaxKind.StringLiteralExpression))
        {
    
            var stringList = new List<string>();
    
            for (int i = 0; i < invocationExpressionSyntax.ArgumentList.Arguments.Count(); i++)
            {
                if (invocationExpressionSyntax.ArgumentList.Arguments[i].Expression.Kind() == SyntaxKind.StringLiteralExpression)
                {
                    stringList.Add("StringManipulation(\"" + invocationExpressionSyntax.ArgumentList.Arguments[i].Expression.GetFirstToken().ValueText + "\")");
                }
                else
                {
                    stringList.Add(invocationExpressionSyntax.ArgumentList.Arguments[i].Expression
                        .GetFirstToken().ValueText);
                }
            }
    
            SeparatedSyntaxList<ArgumentSyntax> arguments = new SeparatedSyntaxList<ArgumentSyntax>().AddRange
            (new ArgumentSyntax[]
                {
                    SyntaxFactory.Argument(SyntaxFactory.ParseExpression($"{string.Join(",", stringList)}")),
                }
            );
    
            var newMethodWithStringObfuscation =
                SyntaxFactory
                    .InvocationExpression(SyntaxFactory.IdentifierName(invocationExpressionSyntax.Expression
                        .GetFirstToken().ValueText))
                    .WithArgumentList(
                        SyntaxFactory.ArgumentList()
                            .WithOpenParenToken(
                                SyntaxFactory.Token(
                                    SyntaxKind.OpenParenToken))
                            .WithArguments(arguments)
                            .WithCloseParenToken(
                                SyntaxFactory.Token(
                                    SyntaxKind.CloseParenToken)));
    
            Console.WriteLine($"Replacing values for method {invocationExpressionSyntax.Expression.GetFirstToken().ValueText}");
    
            editor.ReplaceNode(invocationExpressionSyntax, newMethodWithStringObfuscation);
        }
    }

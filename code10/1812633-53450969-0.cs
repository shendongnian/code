    ...
    // FOR(j, variable | integer, variable | integer, > | < | <= | >=, - | +);
    if (node.Expression is IdentifierNameSyntax identifier && identifier.Identifier.ValueText.Equals("FOR"))
    {
        var arguments = node.ArgumentList.Arguments;
        if (arguments.Count != 5) return node;
        var second = arguments[1].Expression;
        switch (second)
        {
            case IdentifierNameSyntax variable:
                // and some sepcific logic for identifier
                break;
            case LiteralExpressionSyntax literal when literal.Kind() == SyntaxKind.NumericLiteralExpression:
                // and some sepcific logic for literals and check, 
                // that the input literal is integer and is not rational value
                break;
            default:
                // current argument isn't literal or identifier you can not do anything
                return node;
        }
        // do the similar check for the other arguments
        // and replace node as you wish
        ...
    }

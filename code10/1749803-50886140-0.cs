    ...
    var attributeArgument = SyntaxFactory.AttributeArgument(
        null, SyntaxFactory.NameColon("keyAsPropertyName"), SyntaxFactory.LiteralExpression(SyntaxKind.TrueLiteralExpression));
    var attributes = classDecl.AttributeLists.Add(
        SyntaxFactory.AttributeList(SyntaxFactory.SingletonSeparatedList(
            SyntaxFactory.Attribute(SyntaxFactory.IdentifierName("MessagePackObject"))
            .WithArgumentList(SyntaxFactory.AttributeArgumentList(SyntaxFactory.SingletonSeparatedList(attributeArgument)))
        )).NormalizeWhitespace());
    ...

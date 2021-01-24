    var statement = ( StatementSyntax ) root.FindNode( diagnostic.Location.SourceSpan );
    var statements = new SyntaxNode[]
    {
        SomeStatement() , 
        SomeStatement()
    };
    
    return Task.FromResult( context.Document.WithSyntaxRoot( root.ReplaceNode( statement , statements ) ) );

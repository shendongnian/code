    public class MethodDeclarationSyntaxWalker : CSharpSyntaxWalker
    {
        private readonly IList<MethodDeclarationSyntax> _matches;
        public MethodDeclarationSyntaxWalker( IList<MethodDeclarationSyntax> matches )
        {
            _matches = matches;
        }
        public override void VisitBinaryExpression( BinaryExpressionSyntax node )
        {
            if ( node.Kind() == SyntaxKind.AddExpression )
                _matches.Add( node.FirstAncestorOrSelf<MethodDeclarationSyntax>() );
            base.VisitBinaryExpression( node );
        }
    }

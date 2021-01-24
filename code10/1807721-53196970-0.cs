    public class WhitespaceRemover : CSharpSyntaxRewriter
    {
        public override SyntaxNode DefaultVisit(SyntaxNode node) => node.WithoutTrivia();
        public override SyntaxTrivia VisitTrivia(SyntaxTrivia trivia) => default;
    }

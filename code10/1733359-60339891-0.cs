    public class TriviaRemover : CSharpSyntaxRewriter
    {
        public override SyntaxNode Visit(SyntaxNode node) => base.Visit(node).WithoutTrivia();
    
        public override SyntaxTrivia VisitTrivia(SyntaxTrivia trivia) => default;
    }

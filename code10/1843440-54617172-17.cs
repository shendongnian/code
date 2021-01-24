    class AllSymbolsExpander : CSharpSyntaxRewriter
    {
        Document document;
        public AllSymbolsExpander(Document document)
        {
            this.document = document;
        }
        public override SyntaxNode VisitAttribute(AttributeSyntax node) =>
            Expand(node);
        public override SyntaxNode VisitAttributeArgument(AttributeArgumentSyntax node) =>
            Expand(node);
        public override SyntaxNode VisitConstructorInitializer(ConstructorInitializerSyntax node) =>
            Expand(node);
        public override SyntaxNode VisitFieldDeclaration(FieldDeclarationSyntax node) =>
            Expand(node);
        public override SyntaxNode VisitXmlNameAttribute(XmlNameAttributeSyntax node) =>
            Expand(node);
        public override SyntaxNode VisitTypeConstraint(TypeConstraintSyntax node) =>
            Expand(node);
        public override SyntaxNode DefaultVisit(SyntaxNode node)
        {
            if (node is ExpressionSyntax ||
                node is StatementSyntax ||
                node is CrefSyntax ||
                node is BaseTypeSyntax)
                return Expand(node);
            return base.DefaultVisit(node);
        }
        SyntaxNode Expand(SyntaxNode node) =>
            Simplifier.ExpandAsync(node, document).Result; //? async-counterpart?
    }

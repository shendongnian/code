        public override SyntaxNode VisitClassDeclaration(ClassDeclarationSyntax node)
        {
            var tree = node.SyntaxTree;
            var root = tree.GetRoot();            
            var sModel = comp.GetSemanticModel(node.SyntaxTree);
            var classSymbol = sModel.GetDeclaredSymbol(root.DescendantNodes().OfType<ClassDeclarationSyntax>().First());
            var implementedInterfaces = classSymbol.AllInterfaces;
            return base.VisitClassDeclaration(node);
        }

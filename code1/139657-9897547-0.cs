        public static String AddDSuffixesToEquation(String inEquation)
        {
            SyntaxNode syntaxNode = EquationToSyntaxNode(inEquation);
            List<SyntaxNode> branches = syntaxNode.DescendentNodesAndSelf().ToList();
            List<Int32> numericBranchIndexes = new List<int>();
            List<SyntaxNode> replacements = new List<SyntaxNode>();
            SyntaxNode replacement;
            String lStr;
            Int32 L;
            for (L = 0; L < branches.Count; L++)
            {
                if (branches[L].Kind == SyntaxKind.NumericLiteralExpression)
                {
                    numericBranchIndexes.Add(L);
                    lStr = branches[L].ToString() + "d";
                    replacement = EquationToSyntaxNode(lStr);
                    replacements.Add(replacement);
                }
            }
            replacement = EquationToSyntaxNode(inEquation);
            List<SyntaxNode> replaceMeBranches;
            for (L = numericBranchIndexes.Count - 1; L >= 0; L--)
            {
                replaceMeBranches = replacement.DescendentNodesAndSelf().ToList();
                replacement = replacement.ReplaceNode(replaceMeBranches[numericBranchIndexes[L]],replacements[L]);
            }
            return replacement.ToString();
        }
        public static SyntaxNode EquationToSyntaxNode(String inEquation)
        {
            SyntaxTree tree = EquationToSyntaxTree(inEquation);
            return EquationSyntaxTreeToEquationSyntaxNode(tree);
        }
        public static SyntaxTree EquationToSyntaxTree(String inEquation)
        {
            return SyntaxTree.ParseCompilationUnit("using System; class Calc { public static object Eval() { return " + inEquation + "; } }");
        }
        public static SyntaxNode EquationSyntaxTreeToEquationSyntaxNode(SyntaxTree syntaxTree)
        {
            SyntaxNode syntaxNode = syntaxTree.Root.DescendentNodes().First(x => x.Kind == SyntaxKind.ReturnStatement);
            return syntaxNode.ChildNodes().First();
        }

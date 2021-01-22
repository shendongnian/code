    internal class ExpandVisitor : ExpressionVisitor
    {
        protected override Expression VisitBinary(BinaryExpression node)
        {
            var left = Visit(node.Left);
            var right = Visit(node.Right);
            if (node.NodeType == ExpressionType.Multiply)
            {
                Expression[] leftNodes = GetAddedNodes(left).ToArray();
                Expression[] rightNodes = GetAddedNodes(right).ToArray();
                var result =
                    leftNodes
                    .SelectMany(x => rightNodes.Select(y => Expression.Multiply(x, y)))
                    .Aggregate((sum, term) => Expression.Add(sum, term));
                return result;
            }
            if (node.Left == left && node.Right == right)
                return node;
            return Expression.MakeBinary(node.NodeType, left, right, node.IsLiftedToNull, node.Method, node.Conversion);
        }
        /// <summary>
        /// Treats the <paramref name="node"/> as the sum (or difference) of one or more child nodes and returns the
        /// the individual addends in the sum.
        /// </summary>
        private static IEnumerable<Expression> GetAddedNodes(Expression node)
        {
            BinaryExpression binary = node as BinaryExpression;
            if (binary != null)
            {
                switch (binary.NodeType)
                {
                case ExpressionType.Add:
                    foreach (var n in GetAddedNodes(binary.Left))
                        yield return n;
                    foreach (var n in GetAddedNodes(binary.Right))
                        yield return n;
                    yield break;
                case ExpressionType.Subtract:
                    foreach (var n in GetAddedNodes(binary.Left))
                        yield return n;
                    foreach (var n in GetAddedNodes(binary.Right))
                        yield return Expression.Negate(n);
                    yield break;
                default:
                    break;
                }
            }
            yield return node;
        }
    }

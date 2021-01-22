    public static class PropertyPath
    {
        private static readonly PathVisitor Visitor = new PathVisitor();
        public static IReadOnlyList<string> Get<TSource, TResult>(Expression<Func<TSource, TResult>> expression)
        {
            lock (Visitor)
            {
                Visitor._path.Clear();
                Visitor.Visit(expression.Body);
                if (Visitor._path.Any(x => !(x is PropertyInfo)))
                {
                    throw new ArgumentException("The path can only contain properties", nameof(expression));
                }
                Visitor._path.Reverse();
                return Visitor._path.Select(x => x.Name).ToArray();
            }
        }
        private class PathVisitor : ExpressionVisitor
        {
            internal readonly List<MemberInfo> _path = new List<MemberInfo>();
            protected override Expression VisitMember(MemberExpression node)
            {
                _path.Add(node.Member);
                return base.VisitMember(node);
            }
        }
    }

    public static class PropertyPath<TSource>
    {
        public static IReadOnlyList<MemberInfo> Get<TResult>(Expression<Func<TSource, TResult>> expression)
        {
            var visitor = new PropertyVisitor();
            visitor.Visit(expression.Body);
            visitor.Path.Reverse();
            return visitor.Path;
        }
        private class PropertyVisitor : ExpressionVisitor
        {
            internal readonly List<MemberInfo> Path = new List<MemberInfo>();
            protected override Expression VisitMember(MemberExpression node)
            {
                if (!(node.Member is PropertyInfo))
                {
                    throw new ArgumentException("The path can only contain properties", nameof(node));
                }
                this.Path.Add(node.Member);
                return base.VisitMember(node);
            }
        }
    }

    public class PathExpressionVisitor : ExpressionVisitor
    {
        public static string[] GetPath<TSource, TResult>(Expression<Func<TSource, TResult>> expression)
        {
            var visitor = new PathExpressionVisitor();
            visitor.Visit(expression.Body);
            return Enumerable.Reverse(visitor._path).ToArray();
        }
        private readonly List<string> _path = new List<string>();
        protected override Expression VisitMember(MemberExpression node)
        {
            _path.Add(node.Member.Name);
            return base.VisitMember(node);
        }
    }

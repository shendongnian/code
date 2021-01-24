    class MyVisitor : ExpressionVisitor
    {
        public List<string> Names { get; } = new List<string>();
        protected override Expression VisitMember(MemberExpression node)
        {
            if(node.Member.MemberType == MemberTypes.Method)
            {
                Names.Add(node.Member.Name);
            }
            return base.VisitMember(node);
        }
    }

    class ExprVisitor : ExpressionVisitor {
        public bool IsFound { get; private set; }
        public string MemberName { get; private set; }
        public Type MemberType { get; private set; }
        protected override Expression VisitMember(MemberExpression node) {
            if (!IsFound && node.Member.MemberType == MemberTypes.Property) {
                IsFound = true;
                MemberName = node.Member.Name;
                MemberType = node.Type;
            }
            return base.VisitMember(node);
        }
    }

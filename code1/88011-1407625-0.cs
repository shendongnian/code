    public static class MembersOf<T> {
        public static string GetName<R>(Expression<Func<T,R>> expr) {
            var node = expr.Body as MemberExpression;
            if (object.ReferenceEquals(null, node)) 
                throw new InvalidOperationException("Expression must be of member access");
            return node.Member.Name;
        }
    }

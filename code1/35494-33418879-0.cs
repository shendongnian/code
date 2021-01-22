        /// <summary>
        /// From A.B.C and D.E.F makes A.B.C.D.E.F. D must be a member of C.
        /// </summary>
        /// <param name="memberExpression1"></param>
        /// <param name="memberExpression2"></param>
        /// <returns></returns>
        public static MemberExpression JoinExpression(this Expression memberExpression1, MemberExpression memberExpression2)
        {
            var stack = new Stack<MemberInfo>();
            Expression current = memberExpression2;
            while (current.NodeType != ExpressionType.Parameter)
            {
                var memberAccess = current as MemberExpression;
                if (memberAccess != null)
                {
                    current = memberAccess.Expression;
                    stack.Push(memberAccess.Member);
                }
                else
                {
                    throw new NotSupportedException();
                }
            }
            Expression jointMemberExpression = memberExpression1;
            foreach (var memberInfo in stack)
            {
                jointMemberExpression = Expression.MakeMemberAccess(jointMemberExpression, memberInfo);
            }
            return (MemberExpression) jointMemberExpression;
        }

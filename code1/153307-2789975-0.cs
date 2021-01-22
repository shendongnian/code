        internal static string MemberWithoutInstance(this LambdaExpression expression)
        {
            var memberExpression = expression.ToMemberExpression();
            if (memberExpression == null)
            {
                return null;
            }
            if (memberExpression.Expression.NodeType == ExpressionType.MemberAccess)
            {
                var innerMemberExpression = (MemberExpression) memberExpression.Expression;
                while (innerMemberExpression.Expression.NodeType == ExpressionType.MemberAccess)
                {
                    innerMemberExpression = (MemberExpression) innerMemberExpression.Expression;
                }
                var parameterExpression = (ParameterExpression) innerMemberExpression.Expression;
                // +1 accounts for the ".".
                return memberExpression.ToString().Substring(parameterExpression.ToString().Length + 1);
            }
            return memberExpression.Member.Name;
        }
        internal static MemberExpression ToMemberExpression(this LambdaExpression expression)
        {
            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression == null)
            {
                var unaryExpression = expression.Body as UnaryExpression;
                if (unaryExpression != null)
                {
                    memberExpression = unaryExpression.Operand as MemberExpression;
                }
            }
            return memberExpression;
        }
        public static string PropertyToString<TModel, TProperty>(this Expression<Func<TModel, TProperty>> source)
        {
            return source.MemberWithoutInstance();
        }

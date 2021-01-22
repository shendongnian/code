        internal static Expression<Func<TModel, T>> GenExpressionByClause<TModel, T>(string column)
        {
            var columnPropInfo = typeof(TModel).GetProperty(column);
            var formatMethod = typeof (string).GetMethod("Format", new[] {typeof (string), typeof (object)});
            var entityParam = Expression.Parameter(typeof(TModel), "e");
            var columnExpr = Expression.MakeMemberAccess(entityParam, columnPropInfo);
            var formatCall = Expression.Call( formatMethod, Expression.Constant("{0}"), columnExpr);
            var lambda = Expression.Lambda(formatCall , entityParam) as Expression<Func<TModel, T>>;
            return lambda;
        }

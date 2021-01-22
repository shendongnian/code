    internal static Expression<Func<TModel, string>> GenExpressionByClauseEx<TModel>(string column)
        {
            var columnPropInfo = typeof(TModel).GetProperty(column);
            var formatMethod = typeof(String).GetMethod("Format", new[] { typeof(string), typeof(Object) });
            //string.Format(
            var entityParam = Expression.Parameter(typeof(TModel), "e");
            var columnExpr = Expression.MakeMemberAccess(entityParam, columnPropInfo);
            var columnExprObj=Expression.Convert(columnExpr, typeof(object));
            var formatCall = Expression.Call(formatMethod, Expression.Constant("111--{0}"), columnExprObj);
            var lambda = Expression.Lambda(formatCall, entityParam) as Expression<Func<TModel, string>>;
            return lambda;
        }

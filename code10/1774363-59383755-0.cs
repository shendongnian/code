    public static Expression<Func<T2, T1, TResult>> SwapParameters3<T1, T2, TResult>(this Expression<Func<T1, T2, TResult>> exprFunc) {
      var param1 = Expression.Parameter(typeof(T1));
      var param2 = Expression.Parameter(typeof(T2));
      return Expression.Lambda<Func<T2, T1, TResult>>(exprFunc.Body.Replace(exprFunc.Parameters[0], param1).Replace(exprFunc.Parameters[1], param2), param1, param2);
    }
    public static Expression<Func<TNewParam, TResult>> ReplaceParameter<TNewParam, TOldParam, TResult>(this Expression<Func<TOldParam, TResult>> expression) where TNewParam : TOldParam {
      var param = Expression.Parameter(typeof(TNewParam));
      return Expression.Lambda<Func<TNewParam, TResult>>(expression.Body.Replace(expression.Parameters[0], param), param);
    }
    public class ReplaceVisitor : ExpressionVisitor {
      private readonly Expression from, to;
      public ReplaceVisitor(Expression from, Expression to) {
        this.from = from;
        this.to = to;
      }
      public override Expression Visit(Expression node) => node == from ? to : base.Visit(node);
    }
    public static Expression Replace(this Expression expression, Expression searchExpression, Expression replaceExpression) => new ReplaceVisitor(searchExpression, replaceExpression).Visit(expression);

    public class TenantFilterExpressionAdaptor<T, TIdType> {
        public TIdType TenantId { get; set; }
        public Expression<Func<T, bool>> Adapt(Expression<Func<T, TIdType>> idExpression) {
            return Expression.Lambda<Func<T, bool>>(
                Expression.Equal(idExpression.Body, Expression.Constant(TenantId)),
                idExpression.Parameters);
        }
    }

    // How the function is called
    var q = (from t in svc.OpenTransaction.Expand("Currency,LineItem")
             select t)
             .Where(BuildContainsExpression<OpenTransaction, long>(tt => tt.OpenTransactionId, txnIds));
    
  
     // The function to build the contains expression
       static System.Linq.Expressions.Expression<Func<TElement, bool>> BuildContainsExpression<TElement, TValue>(
                    System.Linq.Expressions.Expression<Func<TElement, TValue>> valueSelector, 
                    IEnumerable<TValue> values)
            {
                if (null == valueSelector) { throw new ArgumentNullException("valueSelector"); }
                if (null == values) { throw new ArgumentNullException("values"); }
                System.Linq.Expressions.ParameterExpression p = valueSelector.Parameters.Single();
                
                // p => valueSelector(p) == values[0] || valueSelector(p) == ...
                if (!values.Any())
                {
                    return e => false;
                }
    
                var equals = values.Select(value => (System.Linq.Expressions.Expression)System.Linq.Expressions.Expression.Equal(valueSelector.Body, System.Linq.Expressions.Expression.Constant(value, typeof(TValue))));
                var body = equals.Aggregate<System.Linq.Expressions.Expression>((accumulate, equal) => System.Linq.Expressions.Expression.Or(accumulate, equal));
                return System.Linq.Expressions.Expression.Lambda<Func<TElement, bool>>(body, p);
            }

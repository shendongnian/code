        private static Expression<Func<TElement, bool>> BuildDoesntContainExpression<TElement, TValue>(    
            Expression<Func<TElement, TValue>> valueSelector, IEnumerable<TValue> values)
        {    
            if (null == valueSelector) 
            { 
                throw new ArgumentNullException("valueSelector"); 
            }
            
            if (null == values) 
            { 
                throw new ArgumentNullException("values"); 
            }    
            
            ParameterExpression p = valueSelector.Parameters.Single();    
            
            // p => valueSelector(p) == values[0] || valueSelector(p) == ... 
            if (!values.Any())    
            {        
                return e => false;    
            }    
            
            var equals = values.Select(
                value => (Expression)Expression.NotEqual(valueSelector.Body, Expression.Constant(value, typeof(TValue))));    
            
            var body = equals.Aggregate<Expression>((accumulate, equal) => Expression.And(accumulate, equal));    
            
            return Expression.Lambda<Func<TElement, bool>>(body, p);}
    }

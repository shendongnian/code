    public class SearchCritera<TEntity>
    	{
    		private List<Expression<Func<TEntity, bool>>> _Criteria = new List<Expression<Func<TEntity, bool>>>();
    
    		public void Add(Expression<Func<TEntity, bool>> predicate)
    		{
    			_Criteria.Add(predicate);
    		}
    
    		// This is where your list of Expression get built into a single Expression 
    		// to use in your Where clause
    		public Expression<Func<TEntity, bool>> BuildWhereExpression()
    		{
    			Expression<Func<TEntity, bool>> result = default(Expression<Func<TEntity, bool>>);
    			ParameterExpression parameter = Expression.Parameter(typeof(TEntity), "entity");
    			Expression previous = _Criteria[0];
    
    			for (int i = 1; i < _Criteria.Count; i++)
    			{
    				previous = Expression.And(previous, _Criteria[i]);
    			}
    
    			result = Expression.Lambda<Func<TEntity, bool>>(previous, parameter);
    			
    			return result;
    		}
    	}

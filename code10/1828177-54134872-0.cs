    public interface IQueryDataByPredicateExpression 
    {
    List<TEntity> GetData(Expression<Func<TEntity, Boolean>> whereClause);
    }
    
    public interface IQueryDataByPredicate
    {
    List<TEntity> GetData(Func<TEntity,Boolean> whereClause);
    
    }
    
        public class MyRepo<TEntity> : IQueryDataByPredicateExpression, IQueryDataByPredicate
        {
            public List<TEntity> GetData(Expression<Func<TEntity, Boolean>> expression)
            {
                //Do something
            }
        
            public List<TEntity> GetData(Func<TEntity,Boolean> whereClause)
            {
                //Do something
            }
        }

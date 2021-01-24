    //wrap the translate in base class, so you don't have to do it in each repo
    public class BaseRepo<TEntity, TViewMode> : IGenericRepo<TEntity, TViewMode>
    {
        ....
        public IWhatever<TEntity> Where(Expression<Func<TViewMode, bool>> vmExpression)
        {
            var expression = Mapper.Map<Expression<Func<TEntity, bool>>>(vmExpression);
            return whateverDataOrQuery.Where(expression);
        }
    }

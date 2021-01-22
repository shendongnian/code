        public interface IRepository<TE, TK>
        where TE : class, IEntityId<TK>, new()
        where TK : struct
    {
        IQueryable<TE> Query();
        IQueryable<TE> Query(Expression<Func<TE, Object>> includeExpression);
        IQueryable<TE> Query(IEnumerable<Expression<Func<TE, Object>>> includeExpressions);
        TE GetById(Expression<Func<TE, Boolean>> predicate);
        void Create(TE entity);
        void Update(TE entity);
        void Delete(TE entity);
    }
        public interface IEntityId<out TK> where TK : struct
    {
        TK Id { get; }
        Int32 OwnerCode { get; }
    }

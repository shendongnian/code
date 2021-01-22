    public interface ISpecification<TCandidate>
    {
        IQueryable<TCandidate> GetSatisfyingElements(IQueryable<TCandidate> source);
    }
    public class TestSpecification : ISpecification<TestEntity>
    {
        public IQueryable<TestEntity> GetSatisfyingElements(IQueryable<TestEntity> source)
        {
            return source.Where(x => x.SomeValue == 2);
        }
    }
    
    public class ActiveRecordFooRepository: IFooRepository
    {
        ...
        public IEnumerable<TEntity> Find<TEntity>(ISpecification<TEntity> specification) where TEntity : class 
        {
            ...
            return specification.GetSatisfyingElements(ActiveRecordLinq.AsQueryable<TEntity>()).ToArray();
            ...
        }
        public TEntity FindFirst<TEntity>(ISpecification<TEntity> specification) where TEntity : class 
        {
            return specification.GetSatisfyingElements(ActiveRecordLinq.AsQueryable<TEntity>()).First();
        }
    }

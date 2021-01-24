    public interface IRepository<T> : IDisposable where T : class
    {
        Task UpdateAsync(T entity);
        Task<int> CountAsync(Expression<Func<T, bool>> where);
    }
    public sealed class RepositoryA<T> : IRepository<T> where T : class
    {
        public async Task<int> CountAsync(Expression<Func<T, bool>> where) => throw new NotImplementedException();
        public void Dispose() => throw new NotImplementedException();
        public async Task UpdateAsync(T entity) => throw new NotImplementedException();
        //other methods not common to both repositories
    }
    public sealed class RepositoryB<T> : IRepository<T> where T : class, new()
    {
        public async Task<int> CountAsync(Expression<Func<T, bool>> where) => throw new NotImplementedException();
        public void Dispose() => throw new NotImplementedException();
        public async Task UpdateAsync(T entity) => throw new NotImplementedException();
        //other methods not common to both repositories
    }

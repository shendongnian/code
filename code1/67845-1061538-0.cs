    public class FakeRepository<T> : IResourceRepository<T> where T : class
    {
        private readonly List<T> items = new List<T>();
        private readonly IObjectFactory resolver;
        public FakeRepository(IObjectFactory resolver)
        {
            this.resolver = resolver;
        }
        public IQueryable<T> GetAll()
        {
            return this.items.AsQueryable();
        }
        public void Save(T item)
        {
            if (!this.items.Contains(item))
            {
                this.items.Add(item);
            }
        }
        public void Delete(T item)
        {
            this.items.Remove(item);
        }
        public T Create()
        {
            return this.resolver.GetInstance<T>();
        }
    }

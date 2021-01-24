    public abstract class QueryHandler<T> where T : class
    {
        //I added here more property. 
        public abstract Type[] Types { get; }
        protected QueryHandler(//Properties)
        {
            //Properties null check
        }
        public abstract IQueryable<T> Handle();
    }

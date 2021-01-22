    public class QueryCache<TContext> where TContext : DataContext
    {
        private readonly TContext db;
        public QueryCache(TContext db)
        {
            this.db = db;
        }
        private static readonly Dictionary<string, Delegate> cache = new Dictionary<string, Delegate>();
        public IQueryable<T> Cache<T>(Expression<Func<TContext, IQueryable<T>>> q)
        {
            string key = q.ToString();
            Delegate result;
            lock (cache) if (!cache.TryGetValue(key, out result))
            {
                result = cache[key] = CompiledQuery.Compile(q);
            }
            return ((Func<TContext, IQueryable<T>>)result)(db);
        }
        public IQueryable<T> Cache<T, TArg1>(Expression<Func<TContext, TArg1, IQueryable<T>>> q, TArg1 param1)
        {
            string key = q.ToString();
            Delegate result;
            lock (cache) if (!cache.TryGetValue(key, out result))
            {
                result = cache[key] = CompiledQuery.Compile(q);
            }
            return ((Func<TContext, TArg1, IQueryable<T>>)result)(db, param1);
        }
        public IQueryable<T> Cache<T, TArg1, TArg2>(Expression<Func<TContext, TArg1, TArg2, IQueryable<T>>> q, TArg1 param1, TArg2 param2)
        {
            string key = q.ToString();
            Delegate result;
            lock (cache) if (!cache.TryGetValue(key, out result))
            {
                result = cache[key] = CompiledQuery.Compile(q);
            }
            return ((Func<TContext, TArg1, TArg2, IQueryable<T>>)result)(db, param1, param2);
        }
    }

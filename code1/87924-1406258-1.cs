    public class EntityMap<T> where T : Entity
    {
        private readonly Dictionary<int, T> _entities = new Dictionary<int, T>();
        private readonly object _getLock = new object();
        private readonly Func<T> _entityGenerator;
    
        public T Get(int id)
        {
            lock (_getLock)
            {
                T ret;
                if (!_entities.TryGetValue(id, ret))
                {
                    ret = entityGenerator();
                    newEntity[id] = ret;
                    ret.Id = id;
                }
    
                return ret;
            }
        }
    
        internal EntityMap(Func<T> entityGenerator)
        {
            _entityGenerator = entityGenerator;
        }
    }

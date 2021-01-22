    public abstract class Entity
    {
        private readonly int _id;
        public int Id
        {
            get { return _id; }
        }
        internal Entity(int id)
        {
            _id = id;
        }
    }
    public sealed class Widget : Entity
    {
        internal Widget(int id) : base(id) { }
    }
    public sealed class Gadget : Entity
    {
        internal Gadget(int id) : base(id) { }
    }
    public class EntityMap<T> where T : Entity
    {
        private readonly Dictionary<int, T> _entities = new Dictionary<int, T>();
        private readonly object _getLock = new object();
        private readonly Func<int, T> _entityGenerator;
        public T Get(int id)
        {
            lock (_getLock)
            {
                T entity;
                if (!_entities.TryGetValue(id, out entity))
                    _entities[id] = entity = _entityGenerator(id);
                return entity;
            }
        }
        internal EntityMap(Func<int, T> entityGenerator)
        {
            _entityGenerator = entityGenerator;
        }
    }
    public static class ApplicationMap
    {
        public static readonly EntityMap<Widget> Widgets = new EntityMap<Widget>(id => new Widget(id));
        public static readonly EntityMap<Gadget> Gadgets = new EntityMap<Gadget>(id => new Gadget(id));
    }

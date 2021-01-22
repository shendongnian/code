    public abstract class ObjectBase
    {
        protected ModelBase()
        {
            _objects = new Dictionary<string, object>();
        }
        private readonly Dictionary<string, object> _objects;
        internal void Add<T>(T thing, string name)
        {
            _objects[name] = thing;
        }
        internal T Get<T>(string name)
        {
            T thing = null;
            _objects.TryGetValue(name, out thing);
            return (T) thing;
        }

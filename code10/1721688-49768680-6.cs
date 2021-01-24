    public class Var_Args : IEnumerable<Dictionary<string,object>>
    {
        private struct PropertyList<T>
        {
            public static readonly List<Func<T,Dictionary<string,object>>> PropertyGetters;
    
            static PropertyList()
            {
                PropertyGetters = new List<Func<T,Dictionary<string,object>>>();
                var Properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
    
                foreach (var Property in Properties)
                {
                    var Args = new [] { Expression.Parameter(typeof(T)) };
                    var Key = Property.Name;
                    var Value = Expression.Property(Args[0], Property);
                    Func<T,object> Get = Expression.Lambda<Func<T,object>>(Value, Args).Compile();
    
                    PropertyGetters.Add(obj =>
                    {
                        var entry = new Dictionary<string,object>();
                        entry.Add(Key, Get(obj));
                        return entry;
                    });
                }
            }
        }
    
        protected static IEnumerable<Dictionary<string,object>> GetPropertiesAsEntries<T>(T obj)
        {
            return PropertyList<T>.PropertyGetters.Select(f => f(obj));
        }
    
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    
        public IEnumerator<Dictionary<string,object>> GetEnumerator()
        {
            return GetPropertiesAsEntries(this).GetEnumerator();
        }
    
        public object title { get; set; }
        public object owner { get; set; }
    }

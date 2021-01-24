    public class Var_Args : IEnumerable<Dictionary<string,object>>
    {
        private struct PropertyList<T,E>
            where T : IEnumerable<E>
            where E : Dictionary<string,object>, new()
        {
            public static readonly List<Func<T,E>> PropertyGetters;
    
            static PropertyList()
            {
                PropertyGetters = new List<Func<T,E>>();
                var Properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
    
                foreach (var Property in Properties)
                {
                    var Args = new [] { Expression.Parameter(typeof(T)), Expression.Parameter(typeof(E)) };
                    var Method = typeof(E).GetMethod("Add", new [] { typeof(string), typeof(object) });
                    var Key = Expression.Constant(Property.Name);
                    var Value = Expression.Property(Args[0], Property);
                    var Call = Expression.Call(Args[1], Method, Key, Value);
                    Action<T,E> Assign = Expression.Lambda<Action<T,E>>(Call, Args).Compile();
    
                    PropertyGetters.Add(obj =>
                    {
                        var entry = new E();
                        Assign(obj, entry);
                        return entry;
                    });
                }
            }
        }
    
        protected static IEnumerable<Dictionary<string,object>> GetPropertiesAsEntries<T>(T obj)
            where T : IEnumerable<Dictionary<string,object>>
        {
            return PropertyList<T,Dictionary<string,object>>.PropertyGetters.Select(f => f(obj));
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

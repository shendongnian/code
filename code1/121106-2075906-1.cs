    public class MultiGenericList
    {
        private readonly Dictionary<Type, Object> map = new Dictionary<Type,Object>();
        public List<T> GetList<T>()
        {
            if (!this.map.ContainsKey(typeof(T))) this.map.Add(typeof(T), new List<T>());
            return (List<T>)this.map[typeof(T)];
        }
    }

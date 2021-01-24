    public class Var_Args : IEnumerable<Dictionary<string,object>>
    {
        public object title { get; set; }
        public object owner { get; set; }
    
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    
        public IEnumerator<Dictionary<string,object>> GetEnumerator()
        {
            var Properties = GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
    
            foreach (var Property in Properties)
            {
                var Entry = new Dictionary<string,object>();
                Entry.Add(Property.Name, Property.GetValue(this));
                yield return Entry;
            }
        }
    }

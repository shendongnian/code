    public class MappedProperty
    {
        public MappedProperty(PropertyInfo source)
        {
            this.Info = source;
            this.Source = source.Name;
            this.Target = source.GetCustomAttribute<JsonPropertyAttribute>()?.PropertyName ?? source.Name;
        }
        public PropertyInfo Info { get; }
        public string Source { get; }
        public string Target { get; }
    }

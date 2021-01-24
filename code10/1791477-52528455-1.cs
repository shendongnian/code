    public class CustomContractResolver : DefaultContractResolver
    {
        // Because contracts are cached, WrappedTypes must not be modified after construction.
        readonly HashSet<Type> WrappedTypes = new HashSet<Type>();
        public CustomContractResolver(IEnumerable<Type> wrappedTypes)
        {
            if (wrappedTypes == null)
                throw new ArgumentNullException();
            foreach (var type in wrappedTypes)
                WrappedTypes.Add(type);
        }
        class VersionWrapperProvider<T> : ValueProviderDecorator
        {
            public VersionWrapperProvider(IValueProvider baseProvider) : base(baseProvider) { }
            public override object GetValue(object target)
            {
                return new VersionWrapper<T> { Object = (T)base.GetValue(target) };
            }
            public override void SetValue(object target, object value)
            {
                var wrapper = (VersionWrapper<T>)value;
                base.SetValue(target, wrapper == null ? default(T) : wrapper.Object);
            }
        }
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);
            if (WrappedTypes.Contains(property.PropertyType) 
                && !(member.DeclaringType.IsGenericType && member.DeclaringType.GetGenericTypeDefinition() == typeof(VersionWrapper<>)))
            {
                var wrapperType = typeof(VersionWrapperProvider<>).MakeGenericType(new[] { property.PropertyType });
                property.PropertyType = wrapperType;
                property.ValueProvider = (IValueProvider)Activator.CreateInstance(wrapperType, property.ValueProvider);
            }
            return property;
        }
    }
    public class VersionWrapper<T>
    {
        public int Version { get { return 1; } }
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public T Object { get; set; }
    }
    public abstract class ValueProviderDecorator : IValueProvider
    {
        readonly IValueProvider baseProvider;
        public ValueProviderDecorator(IValueProvider baseProvider)
        {
            if (baseProvider == null)
                throw new ArgumentNullException();
            this.baseProvider = baseProvider;
        }
        public virtual object GetValue(object target) { return baseProvider.GetValue(target); }
        public virtual void SetValue(object target, object value) { baseProvider.SetValue(target, value); }
    }

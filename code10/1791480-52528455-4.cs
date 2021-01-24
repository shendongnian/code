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
        class VersionWrapperProvider<T> : IValueProvider
        {
            readonly IValueProvider baseProvider;
            public VersionWrapperProvider(IValueProvider baseProvider)
            {
                if (baseProvider == null)
                    throw new ArgumentNullException();
                this.baseProvider = baseProvider;
            }
            public object GetValue(object target)
            {
                return new VersionWrapper<T>(target, baseProvider);
            }
            public void SetValue(object target, object value) { }
        }
        class ReadOnlyVersionWrapperProvider<T> : IValueProvider
        {
            readonly IValueProvider baseProvider;
            public ReadOnlyVersionWrapperProvider(IValueProvider baseProvider)
            {
                if (baseProvider == null)
                    throw new ArgumentNullException();
                this.baseProvider = baseProvider;
            }
            public object GetValue(object target)
            {
                return new ReadOnlyVersionWrapper<T>(target, baseProvider);
            }
            public void SetValue(object target, object value) { }
        }
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);
            if (WrappedTypes.Contains(property.PropertyType) 
                && !(member.DeclaringType.IsGenericType 
                    && (member.DeclaringType.GetGenericTypeDefinition() == typeof(VersionWrapper<>) || member.DeclaringType.GetGenericTypeDefinition() == typeof(ReadOnlyVersionWrapper<>))))
            {
                var wrapperGenericType = (property.Writable ? typeof(VersionWrapper<>) : typeof(ReadOnlyVersionWrapper<>));
                var providerGenericType = (property.Writable ? typeof(VersionWrapperProvider<>) : typeof(ReadOnlyVersionWrapperProvider<>));
                var wrapperType = wrapperGenericType.MakeGenericType(new[] { property.PropertyType });
                var providerType = providerGenericType.MakeGenericType(new[] { property.PropertyType });
                property.PropertyType = wrapperType;
                property.ValueProvider = (IValueProvider)Activator.CreateInstance(providerType, property.ValueProvider);
                property.ObjectCreationHandling = ObjectCreationHandling.Reuse;
            }
            return property;
        }
    }
    internal class VersionWrapper<T>
    {
        readonly object target;
        readonly IValueProvider baseProvider;
        public VersionWrapper(object target, IValueProvider baseProvider)
        {
            this.target = target;
            this.baseProvider = baseProvider;
        }
        public int Version { get { return 1; } }
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public T Object 
        {
            get
            {
                return (T)baseProvider.GetValue(target);
            }
            set
            {
                baseProvider.SetValue(target, value);
            }
        }
    }
    internal class ReadOnlyVersionWrapper<T>
    {
        readonly object target;
        readonly IValueProvider baseProvider;
        public ReadOnlyVersionWrapper(object target, IValueProvider baseProvider)
        {
            this.target = target;
            this.baseProvider = baseProvider;
        }
        public int Version { get { return 1; } }
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public T Object
        {
            get
            {
                return (T)baseProvider.GetValue(target);
            }
        }
    }

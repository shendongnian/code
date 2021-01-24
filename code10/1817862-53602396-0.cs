    public static class CachedPropertyAccessUtilsFactory
    {
        public static CachedPropertyAccessUtils<T> Create<T>(T instance)
        {
            return new CachedPropertyAccessUtils<T>(instance);
        }
    }
    public class CachedPropertyAccessUtils<TWrappedType>
    {
        private readonly TWrappedType _instance;
        public CachedPropertyAccessUtils(TWrappedType instance)
        {
            _instance = instance;
        }
        public GetSetWrapper<TProperty> Property<TProperty>(string propertyName)
        {
            return new GetSetWrapper<TProperty>(_instance, propertyName);
        }
        public class GetSetWrapper<TProperty>
        {
            private static readonly ConcurrentDictionary<string, GetterAndSetterTuple> GettersAndSettersByPropertyName
                = new ConcurrentDictionary<string, GetterAndSetterTuple>();
            private readonly TWrappedType _instance;
            private readonly string _propertyName;
            public GetSetWrapper(TWrappedType instance, string propertyName)
            {
                _instance = instance;
                _propertyName = propertyName;
                GettersAndSettersByPropertyName.GetOrAdd(propertyName, (ignored) => new GetterAndSetterTuple() {
                    Getter = (Func<TWrappedType, TProperty>)Delegate.CreateDelegate(typeof(Func<TWrappedType, TProperty>), null, typeof(TWrappedType).GetProperty(propertyName).GetGetMethod()),
                    Setter = (Action<TWrappedType, TProperty>)Delegate.CreateDelegate(typeof(Action<TWrappedType, TProperty>), null, typeof(TWrappedType).GetProperty(propertyName).GetSetMethod())
                });
            }
            public TProperty GetValue()
                => GettersAndSettersByPropertyName[_propertyName].Getter(_instance);
            public GetSetWrapper<TProperty> SetValue(TProperty value)
            {
                GettersAndSettersByPropertyName[_propertyName].Setter(_instance, value);
                return this;
            }
            class GetterAndSetterTuple
            {
                public Func<TWrappedType, TProperty> Getter { get; set; }
                public Action<TWrappedType, TProperty> Setter { get; set; }
            }
        }
    }

    public static class CachedPropertyAccessUtilsFactory
    {
        /*
         * Convenience Factory to avoid creating instances of
         * CachedPropertyAccessUtils by reflection
         */
        public static CachedPropertyAccessUtils<TWrappedType> Create<TWrappedType>(
            TWrappedType instance)
        {
            return new CachedPropertyAccessUtils<TWrappedType>(instance);
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
            /*
             * Caches generated getters/setters by property name.
             * Since this field is static it is shared between all instances with
             * identical TWrappedType and TProperty.
             */
            private static readonly ConcurrentDictionary<string, GetterAndSetterTuple> GettersAndSettersByPropertyName
                = new ConcurrentDictionary<string, GetterAndSetterTuple>();
            private readonly TWrappedType _instance;
            private readonly string _propertyName;
            public GetSetWrapper(TWrappedType instance, string propertyName)
            {
                _instance = instance;
                _propertyName = propertyName;
                // Create a Getter/Setter pair if none has been generated previously
                GettersAndSettersByPropertyName.GetOrAdd(propertyName, (ignored) => new GetterAndSetterTuple() {
                    Getter = (Func<TWrappedType, TProperty>)Delegate
                        .CreateDelegate(typeof(Func<TWrappedType, TProperty>),
                            null,
                            typeof(TWrappedType)
                                .GetProperty(propertyName)
                                .GetGetMethod()),
                    Setter = (Action<TWrappedType, TProperty>)Delegate
                        .CreateDelegate(typeof(Action<TWrappedType, TProperty>),
                            null,
                            typeof(TWrappedType)
                                .GetProperty(propertyName)
                                .GetSetMethod())
                });
            }
            public TProperty GetValue()
            {
                return GettersAndSettersByPropertyName[_propertyName].Getter(_instance);
            }
            public GetSetWrapper<TProperty> SetValue(TProperty value)
            {
                GettersAndSettersByPropertyName[_propertyName].Setter(_instance, value);
                return this;
            }
            class GetterAndSetterTuple
            {
                public Func  <TWrappedType, TProperty> Getter { get; set; }
                public Action<TWrappedType, TProperty> Setter { get; set; }
            }
        }
    }

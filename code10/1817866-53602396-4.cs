    public static class CachedPropertyAccessUtilsFactory
    {
        /*
         * Convenience Factory to avoid creating instances of
         * CachedPropertyAccessUtils by reflection
         */
        public static CachedPropertyAccessUtils<TWrapped> Create<TWrapped>(
            TWrapped instance)
        {
            return new CachedPropertyAccessUtils<TWrapped>(instance);
        }
    }
    public class CachedPropertyAccessUtils<TWrapped>
    {
        private readonly TWrapped _instance;
        public CachedPropertyAccessUtils(TWrapped instance)
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
             * identical TWrapped and TProperty.
             */
            private static readonly ConcurrentDictionary<string, GetterAndSetterTuple> GettersAndSettersByPropertyName
                = new ConcurrentDictionary<string, GetterAndSetterTuple>();
            private readonly TWrapped _instance;
            private readonly string _propertyName;
            public GetSetWrapper(TWrapped instance, string propertyName)
            {
                _instance = instance;
                _propertyName = propertyName;
                // Create a Getter/Setter pair if none has been generated previously
                GettersAndSettersByPropertyName.GetOrAdd(propertyName, (ignored) => new GetterAndSetterTuple() {
                    Getter = (Func<TWrapped, TProperty>)Delegate
                        .CreateDelegate(typeof(Func<TWrapped, TProperty>),
                            null,
                            typeof(TWrapped)
                                .GetProperty(propertyName)
                                .GetGetMethod()),
                    Setter = (Action<TWrapped, TProperty>)Delegate
                        .CreateDelegate(typeof(Action<TWrapped, TProperty>),
                            null,
                            typeof(TWrapped)
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
                public Func  <TWrapped, TProperty> Getter { get; set; }
                public Action<TWrapped, TProperty> Setter { get; set; }
            }
        }
    }

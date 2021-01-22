    public static class MetaProperty
    {
        // Make it convenient for us to fill in the meta information
        private interface IMetaPropertyInit
        {
            string DisplayName { get; set; }
        }
        // Implementation of a meta-property
        private class MetaPropertyImpl<TValue> : IMetaProperty<TValue>, 
                                                 IMetaPropertyInit
        {
            private TValue _value;
            public TValue Value
            {
                get { return _value; }
                set
                {
                    var old = _value;
                    _value = value;
                    ValueChanged(old, _value);
                }
            }
            public string DisplayName { get; set; }
            public event Action<TValue, TValue> ValueChanged = delegate { };
        }
        public static void Inject(object target)
        {
            // for each meta property...
            foreach (var property in target.GetType().GetProperties()
                .Where(p => p.PropertyType.IsGenericType && 
                            p.PropertyType.GetGenericTypeDefinition() 
                                == typeof(IMetaProperty<>)))
            {
                // construct an implementation with the correct type
                var impl = (IMetaPropertyInit) 
                    typeof (MetaPropertyImpl<>).MakeGenericType(
                        property.PropertyType.GetGenericArguments()
                    ).GetConstructor(Type.EmptyTypes).Invoke(null);
                // initialize any meta info (could examine attributes...)
                impl.DisplayName = property.Name;
                // set the value
                property.SetValue(target, impl, null);
            }
        }
    }

    class EntityWrapper<T> : CustomTypeDescriptor
    {
        public EntityWrapper(T entity)
        {
            this.Entity = entity;
            var properties = TypeDescriptor.GetProperties(typeof(T))
                        .Cast<PropertyDescriptor>()
                        .ToArray();
            ReadOnly = properties.ToDictionary(p => p.Name, p => p.IsReadOnly);
            _properties = new PropertyDescriptorCollection(properties
                                .Select(p => new WrapperPropertyDescriptor(p, this))
                                .ToArray());
        }
        public T Entity { get; private set; }
        public Dictionary<string, bool> ReadOnly { get; private set; }
        public override PropertyDescriptorCollection GetProperties()
        {
            return _properties;
        }
        public override PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            return _properties;
        }
        private PropertyDescriptorCollection _properties;
        private class WrapperPropertyDescriptor : PropertyDescriptor
        {
            private EntityWrapper<T> _entityWrapper;
            private PropertyDescriptor _property;
            public WrapperPropertyDescriptor(PropertyDescriptor property, EntityWrapper<T> entityWrapper)
                : base(property)
            {
                _property = property;
                _entityWrapper = entityWrapper;
            }
            public override bool CanResetValue(object component)
            {
                return _property.CanResetValue(component);
            }
            public override Type ComponentType
            {
                get { return _property.ComponentType; }
            }
            public override object GetValue(object component)
            {
                return _property.GetValue(component);
            }
            public override bool IsReadOnly
            {
                get
                {
                    return _entityWrapper.ReadOnly[this.Name];
                }
            }
            public override Type PropertyType
            {
                get { return _property.PropertyType; }
            }
            public override void ResetValue(object component)
            {
                _property.ResetValue(component);
            }
            public override void SetValue(object component, object value)
            {
                _property.SetValue(component, value);
            }
            public override bool ShouldSerializeValue(object component)
            {
                return _property.ShouldSerializeValue(component);
            }
        }
    }

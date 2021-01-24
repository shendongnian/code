    public class NeverImmutableProvider : TypeDescriptionProvider
    {
        public NeverImmutableProvider(Type type)
            : base(TypeDescriptor.GetProvider(type))
        {
        }
        public override ICustomTypeDescriptor GetTypeDescriptor(Type objectType, object instance) => new MyTypeProvider(base.GetTypeDescriptor(objectType, instance));
        private class MyTypeProvider : CustomTypeDescriptor
        {
            public MyTypeProvider(ICustomTypeDescriptor parent)
                : base(parent)
            {
            }
            public override PropertyDescriptorCollection GetProperties() => GetProperties(null);
            public override PropertyDescriptorCollection GetProperties(Attribute[] attributes)
            {
                var props = new List<PropertyDescriptor>(base.GetProperties(attributes).Cast<PropertyDescriptor>());
                props.Add(new MyProp());
                return new PropertyDescriptorCollection(props.ToArray());
            }
        }
        private class MyProp : PropertyDescriptor
        {
            public MyProp()
                : base("dummy", new Attribute[] { new BrowsableAttribute(false) })
            {
            }
            // this is the important thing, it must not be readonly
            public override bool IsReadOnly => false;
            public override Type ComponentType => typeof(object);
            public override Type PropertyType => typeof(object);
            public override bool CanResetValue(object component) => true;
            public override object GetValue(object component) => null;
            public override void ResetValue(object component) { }
            public override void SetValue(object component, object value) { }
            public override bool ShouldSerializeValue(object component) => false;
        }
    }

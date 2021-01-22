    class CustomTypeProvider<T> : TypeDescriptionProvider
    {
        private static TypeDescriptionProvider defaultTypeProvider = TypeDescriptor.GetProvider(typeof(T));
    
        public CustomTypeProvider(): base(defaultTypeProvider)
        {
    
        }
    
        public override ICustomTypeDescriptor GetTypeDescriptor(Type objectType, object instance)
        {
            ICustomTypeDescriptor defaultDescriptor = base.GetTypeDescriptor(objectType, instance);
    
            //returns a custom type descriptor based on a UserPropertyHostType enum value, and the default descriptor
            return new InfCustomTypeDescriptor(UserPropertyHostType.SiteRegion, defaultDescriptor);
        }
    }

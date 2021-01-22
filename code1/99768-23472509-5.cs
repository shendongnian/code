    public class AbstractControlDescriptionProvider<TAbstract, TBase> : TypeDescriptionProvider
    {
        public AbstractControlDescriptionProvider()
            : base(TypeDescriptor.GetProvider(typeof(TAbstract)))
        {
        }
        public override Type GetReflectionType(Type objectType, object instance)
        {
            if (objectType.FullName == typeof(TAbstract).FullName)  // corrected condition here (original condition was incorrectly giving false in my case sometimes)
                return typeof(TBase);
            return base.GetReflectionType(objectType, instance);
        }
        public override object CreateInstance(IServiceProvider provider, Type objectType, Type[] argTypes, object[] args)
        {
            if (objectType.FullName == typeof(TAbstract).FullName)  // corrected condition here (original condition was incorrectly giving false in my case sometimes)
                objectType = typeof(TBase);
            return base.CreateInstance(provider, objectType, argTypes, args);
        }
    }

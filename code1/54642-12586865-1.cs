    public class ViewModel<T> : CustomTypeDescriptor
    {
        private T _instance;
        private ICustomTypeDescriptor _originalDescriptor;
        public ViewModel(T instance, ICustomTypeDescriptor originalDescriptor) : base(originalDescriptor)
        {
            _instance = instance;
            _originalDescriptor = originalDescriptor;
            PropertyAttributeReplacements = new Dictionary<Type,IList<Attribute>>();
        }
        public static ViewModel<T> DressUp(T instance)
        {
            return new ViewModel<T>(instance, TypeDescriptor.GetProvider(instance).GetTypeDescriptor(instance));
        }
        /// <summary>
        /// Most useful for changing EditorAttribute and TypeConvertorAttribute
        /// </summary>
        public IDictionary<Type,IList<Attribute>> PropertyAttributeReplacements {get; set; } 
        public override PropertyDescriptorCollection GetProperties (Attribute[] attributes)
        {
            var properties = base.GetProperties(attributes).Cast<PropertyDescriptor>();
            var bettered = properties.Select(pd =>
                {
                    if (PropertyAttributeReplacements.ContainsKey(pd.PropertyType))
                    {
                        return TypeDescriptor.CreateProperty(typeof(T), pd, PropertyAttributeReplacements[pd.PropertyType].ToArray());
                    }
                    else
                    {
                        return pd;
                    }
                });
            return new PropertyDescriptorCollection(bettered.ToArray());
        }
        public override PropertyDescriptorCollection GetProperties()
        {
            return GetProperties(null);
        }
    }

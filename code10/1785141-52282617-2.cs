    class CustomContractResolver : DefaultContractResolver
    {
		class NullToDefaultValueProvider : ValueProviderDecorator
		{
			readonly object defaultValue;
		
			public NullToDefaultValueProvider(IValueProvider baseProvider, object defaultValue) : base(baseProvider)
			{
				this.defaultValue = defaultValue;
			}
			
			public override void SetValue(object target, object value)
			{
				base.SetValue(target, value ?? defaultValue);
			}
		}
	
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);
            if (property != null && property.PropertyType.IsValueType && Nullable.GetUnderlyingType(property.PropertyType) == null && property.Writable)
            {
                var defaultValue = property.DefaultValue ?? Activator.CreateInstance(property.PropertyType);
                // When a null value is encountered in the JSON we want to set a default value in the class.
                property.PropertyType = typeof(Nullable<>).MakeGenericType(new[] { property.PropertyType });
                property.ValueProvider = new NullToDefaultValueProvider(property.ValueProvider, defaultValue);
                // Remember that the underlying property is actually not nullable so GetValue() will never return null.
                // Thus the below just overrides JsonSerializerSettings.NullValueHandling to force the value to be set
                // (to the default) even when null is encountered.
                property.NullValueHandling = NullValueHandling.Include;
            }
            return property;
        }
        // As of 7.0.1, Json.NET suggests using a static instance for "stateless" contract resolvers, for performance reasons.
        // http://www.newtonsoft.com/json/help/html/ContractResolver.htm
        // http://www.newtonsoft.com/json/help/html/M_Newtonsoft_Json_Serialization_DefaultContractResolver__ctor_1.htm
        // "Use the parameterless constructor and cache instances of the contract resolver within your application for optimal performance."
        // See also https://stackoverflow.com/questions/33557737/does-json-net-cache-types-serialization-information
        static CustomContractResolver instance;
        // Explicit static constructor to tell C# compiler not to mark type as beforefieldinit
        static CustomContractResolver() { instance = new CustomContractResolver(); }
        public static CustomContractResolver Instance { get { return instance; } }
    }
    public abstract class ValueProviderDecorator : IValueProvider
    {
        readonly IValueProvider baseProvider;
        public ValueProviderDecorator(IValueProvider baseProvider)
        {
            if (baseProvider == null)
                throw new ArgumentNullException();
            this.baseProvider = baseProvider;
        }
        public virtual object GetValue(object target) { return baseProvider.GetValue(target); }
        public virtual void SetValue(object target, object value) { baseProvider.SetValue(target, value); }
    }

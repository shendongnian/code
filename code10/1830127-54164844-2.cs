    public class ArrayDefaultValueContractResolver : DefaultContractResolver
    {
        class ArrayDefaultValueProvider<T> : IValueProvider
        {
            readonly IValueProvider baseProvider;
            readonly System.Array defaultValue;
            public ArrayDefaultValueProvider(IValueProvider baseProvider, System.Array defaultValue)
            {
                this.baseProvider = baseProvider;
                this.defaultValue = defaultValue;
            }
            #region IValueProvider Members
            public object GetValue(object target)
            {
                return baseProvider.GetValue(target);
            }
            public void SetValue(object target, object value)
            {
                // Make sure the default value is cloned since arrays are not truly read only.
                if (value != null && object.ReferenceEquals(value, defaultValue))
                    value = defaultValue.Clone();
                baseProvider.SetValue(target, value);
            }
            #endregion
        }
        static void AddArrayDefaultHandling<T>(JsonProperty property)
        {
            var defaultValue = (T [])property.DefaultValue;
            // If the default value has length > 0, clone it when setting it back into the object.
            if (defaultValue.Length > 0)
            {
                property.ValueProvider = new ArrayDefaultValueProvider<T>(property.ValueProvider, defaultValue);
            }
            // Add a ShouldSerialize method that checks for memberwise array equality.
            var valueProvider = property.ValueProvider;
            var oldShouldSerialize = property.ShouldSerialize;
            Predicate<object> shouldSerialize = target =>
                {
                    var array = (T[])valueProvider.GetValue(target);
                    return !(array == null || array.SequenceEqual(defaultValue));
                };
            if (oldShouldSerialize == null)
                property.ShouldSerialize = shouldSerialize;
            else
                property.ShouldSerialize = (target) => shouldSerialize(target) && oldShouldSerialize(target);
        }
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            if (property.PropertyType.IsArray && property.DefaultValue != null && property.DefaultValue.GetType() == property.PropertyType
                && property.PropertyType.GetArrayRank() == 1)
            {
                typeof(ArrayDefaultValueContractResolver)
                    .GetMethod("AddArrayDefaultHandling", BindingFlags.Static | BindingFlags.NonPublic)
                    .MakeGenericMethod(property.PropertyType.GetElementType())
                    .Invoke(null, BindingFlags.Static | BindingFlags.NonPublic, null, new [] { property }, null);
            }
            return property;
        }
    }

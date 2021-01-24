    public class IgnoreZeroContractResolver : DefaultContractResolver
    {
        public IgnoreZeroContractResolver( ){ }
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);
            property.ShouldSerialize = instance => {
                var shouldSerialize = true;  // indicate should we serialize this property
                var type = instance.GetType();
                var pi = type.GetProperty(property.PropertyName);  
                var pv = pi.GetValue(instance);
                var pvType = pv.GetType();
                // if current value equals the default values , ignore this property 
                if (pv.GetType().IsValueType){
                    var defaultValue = Activator.CreateInstance(pvType);  
                    if (pv.Equals(defaultValue)) { shouldSerialize = false; } 
                }
                return shouldSerialize;
            };
            return property;
        }
    }

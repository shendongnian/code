    public class IgnoreParentPropertiesResolver : DefaultContractResolver
    {
        bool IgnoreBase = false;
        public IgnoreParentPropertiesResolver(bool ignoreBase)
        {
            IgnoreBase = ignoreBase;
        }
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var allProps = base.CreateProperties(type, memberSerialization);
            if (!IgnoreBase) return allProps;
            //Choose the properties you want to serialize/deserialize
            var props = type.GetProperties(~BindingFlags.FlattenHierarchy); 
            return allProps.Where(p => props.Any(a => a.Name == p.PropertyName)).ToList();
        }
    }

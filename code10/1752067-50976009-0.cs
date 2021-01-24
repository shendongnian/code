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
            var props = type.GetProperties( BindingFlags.Instance |  ~BindingFlags.FlattenHierarchy).ToList();
            return allProps.Where(p => props.Any(a => a.Name == p.PropertyName)).ToList();
        }
    }

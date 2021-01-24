    public class ConverterDisablingContractResolver : DefaultContractResolver
    {
        readonly HashSet<Type> types;
        public ConverterDisablingContractResolver(IEnumerable<Type> types)
        {
            if (types == null)
                throw new ArgumentNullException();
            this.types = new HashSet<Type>(types);
        }
        bool ContainsType(Type type)
        {
            return types.Contains(type);
        }
        protected override JsonConverter ResolveContractConverter(Type objectType)
        {
            // This could be enhanced to deal with inheritance.  I.e. if TBase is in types and has a converter then
            // its converter should not be used for TDerived -- but if TDerived has its own converter then it should still be
            // used, so simply returning null for TDerived would be wrong.
            if (types.Contains(objectType))
                return null;
            return base.ResolveContractConverter(objectType);
        }
    }

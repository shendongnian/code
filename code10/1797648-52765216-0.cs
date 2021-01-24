    public class SelectiveValueEqualityReferenceResolver : EquivalencingReferenceResolver
    {
        readonly Dictionary<Type, Dictionary<object, object>> representatives;
        public SelectiveValueEqualityReferenceResolver(IReferenceResolver defaultResolver, IEnumerable<Type> valueTypes)
            : base(defaultResolver)
        {
            if (valueTypes == null)
                throw new ArgumentNullException();
            representatives = valueTypes.ToDictionary(t => t, t => new Dictionary<object, object>());
        }
        protected override bool TryGetRepresentativeObject(object obj, out object representative)
        {
            var type = obj.GetType();
            Dictionary<object, object> typedItems;
            if (representatives.TryGetValue(type, out typedItems))
            {
                return typedItems.TryGetValue(obj, out representative);
            }
            return base.TryGetRepresentativeObject(obj, out representative);
        }
        protected override object GetOrAddRepresentativeObject(object obj)
        {
            var type = obj.GetType();
            Dictionary<object, object> typedItems;
            if (representatives.TryGetValue(type, out typedItems))
            {
                object representative;
                if (!typedItems.TryGetValue(obj, out representative))
                    representative = (typedItems[obj] = obj);
                return representative;
            }
            return base.GetOrAddRepresentativeObject(obj);
        }
    }
    public abstract class EquivalencingReferenceResolver : IReferenceResolver
    {
        readonly IReferenceResolver defaultResolver;
        public EquivalencingReferenceResolver(IReferenceResolver defaultResolver)
        {
            if (defaultResolver == null)
                throw new ArgumentNullException();
            this.defaultResolver = defaultResolver;
        }
        protected virtual bool TryGetRepresentativeObject(object obj, out object representative)
        {
            representative = obj;
            return true;
        }
        protected virtual object GetOrAddRepresentativeObject(object obj)
        {
            return obj;
        }
        #region IReferenceResolver Members
        public void AddReference(object context, string reference, object value)
        {
            var representative = GetOrAddRepresentativeObject(value);
            defaultResolver.AddReference(context, reference, representative);
        }
        public string GetReference(object context, object value)
        {
            var representative = GetOrAddRepresentativeObject(value);
            return defaultResolver.GetReference(context, representative);
        }
        public bool IsReferenced(object context, object value)
        {
            object representative;
            if (!TryGetRepresentativeObject(value, out representative))
                return false;
            return defaultResolver.IsReferenced(context, representative);
        }
        public object ResolveReference(object context, string reference)
        {
            return defaultResolver.ResolveReference(context, reference);
        }
        #endregion
    }

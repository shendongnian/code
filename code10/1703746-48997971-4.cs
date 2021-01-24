    public class IncludeMethodsContractResolver : DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var properties = base.CreateProperties(type, memberSerialization);
            return properties.Concat(this.GetMethodProperties(type, memberSerialization)).ToList();
        }
    }
    internal static class ContractResolverExtensions
    {
        static readonly HashSet<string> objectMethods;
        static ContractResolverExtensions()
        {
            objectMethods = new HashSet<string>(typeof(object).GetMethods().Where(m => IsCallableMethod(m)).Select(m => m.Name));
        }
        static Func<object, object> CreateMethodGetterGeneric<TObject, TValue>(MethodInfo method)
        {
            if (method == null)
                throw new ArgumentNullException();
            var func = (Func<TObject, TValue>)Delegate.CreateDelegate(typeof(Func<TObject, TValue>), method);
            return (o) => func((TObject)o);
        }
        static Func<object, object> CreateMethodGetter(MethodInfo method, Type type)
        {
            var myMethod = typeof(ContractResolverExtensions).GetMethod("CreateMethodGetterGeneric", BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Public);
            return (Func<object, object>)myMethod.MakeGenericMethod(new[] { type, method.ReturnType }).Invoke(null, new [] { method });
        }
        static bool IsCallableMethod(MethodInfo m)
        {
            return !m.ContainsGenericParameters && m.GetParameters().Length == 0 && !m.IsAbstract && m.ReturnType != typeof(void) && !m.IsSpecialName;
        }
        public static IEnumerable<JsonProperty> GetMethodProperties(this DefaultContractResolver resolver, Type type, MemberSerialization memberSerialization)
        {
            if (type.IsValueType || memberSerialization == MemberSerialization.Fields || memberSerialization == MemberSerialization.OptIn)
                return Enumerable.Empty<JsonProperty>();
            var query = from m in type.GetMethods()
                        where IsCallableMethod(m)
                        where !objectMethods.Contains(m.Name) // Skip ToString(), GetHashCode() and GetType() and the like
                        let v = new MethodProvider(CreateMethodGetter(m, type))
                        select new JsonProperty
                        {
                            DeclaringType = type, 
                            PropertyType = m.ReturnType,
                            PropertyName = resolver.GetResolvedPropertyName(m.Name),
                            UnderlyingName = m.Name,
                            ValueProvider = v,
                            AttributeProvider = NoAttributeProvider.Instance,
                            Readable = true,
                            Writable = false,
                        };
            return query;
        }
    }
    class NoAttributeProvider : IAttributeProvider
    {
        static NoAttributeProvider() { instance = new NoAttributeProvider(); }
        static readonly NoAttributeProvider instance;
        public static NoAttributeProvider Instance { get { return instance; } }
        public IList<Attribute> GetAttributes(Type attributeType, bool inherit) { return new Attribute[0]; }
        public IList<Attribute> GetAttributes(bool inherit) { return new Attribute[0]; }
    }
    class MethodProvider : IValueProvider
    {
        readonly Func<object, object> methodGetter;
        public MethodProvider(Func<object, object> methodGetter)
        {
            if (methodGetter == null)
                throw new ArgumentNullException();
            this.methodGetter = methodGetter;
        }
        #region IValueProvider Members
        public object GetValue(object target)
        {
            return methodGetter(target);
        }
        public void SetValue(object target, object value)
        {
            throw new NotImplementedException();
        }
        #endregion
    }

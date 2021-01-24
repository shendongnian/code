    using FastMember;
    ...
    public static class DomainExtensions
    {
        private static readonly IDictionary<Type, TypeAccessor> _accessors = new Dictionary<Type, TypeAccessor>();
        public static T With<T, TFieldOrProperty>(this T instance, Expression<Func<T, TFieldOrProperty>> fieldOrProperty, TFieldOrProperty value)
            where T : class
        {
            if (instance == null)
                return null;
            if (!(fieldOrProperty.Body is MemberExpression member))
                throw new ArgumentException($"Expression '{fieldOrProperty}' is not for a property or field.");
            try
            {
                if (!_accessors.TryGetValue(typeof(T), out var ta))
                    lock (_accessors)
                        ta = _accessors[typeof(T)] = TypeAccessor.Create(typeof(T), true);
                if (ta[instance, member.Member.Name] != null)
                {
                    ta[instance, member.Member.Name] = value;
                    return instance;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            // fallback to reflection
            var fi = member.Member as FieldInfo;
            fi?.SetValue(instance, value);
            var pi = member.Member as PropertyInfo;
            pi?.SetValue(instance, value);
            return instance;
        }

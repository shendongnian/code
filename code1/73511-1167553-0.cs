    private static readonly Dictionary<DependencyProperty, Type> _ownerCache = new Dictionary<DependencyProperty, Type>();
    // normally you'd use a HashSet<DependencyProperty>, but it's not available in SilverLight
    private static readonly Dictionary<Type, Dictionary<DependencyProperty, bool>> _excludeCache = new Dictionary<Type, Dictionary<DependencyProperty, bool>>();
    public static bool IsOwnedByTypeOrParent(DependencyProperty dp, Type type)
    {
        lock (_ownerCache)
        {
            Type owner;
            if (_ownerCache.TryGetValue(dp, out owner))
                return owner.IsAssignableFrom(type);
            Dictionary<DependencyProperty, bool> exclude;
            if (_excludeCache.TryGetValue(type, out exclude))
            {
                if (exclude.ContainsKey(dp))
                    return false;
            }
            FieldInfo[] fields = type.GetFields(BindingFlags.Static | BindingFlags.FlattenHierarchy);
            foreach (FieldInfo field in fields)
            {
                if (typeof(DependencyProperty).IsAssignableFrom(field.FieldType))
                {
                    try
                    {
                        object value = field.GetValue(null);
                        if (object.ReferenceEquals(dp, value))
                        {
                            _ownerCache[dp] = field.DeclaringType;
                            return true;
                        }
                    }
                    catch
                    {
                    }
                }
            }
            if (exclude == null)
            {
                exclude = new Dictionary<DependencyProperty, bool>();
                _excludeCache[type] = exclude;
            }
            exclude.Add(dp, false);
            /* optional if you want to minimize memory overhead. unnecessary unless
             * you are using this on enormous numbers of types/DPs
             */
            foreach (var item in _excludeCache)
            {
                item.Value.Remove(dp);
            }
            return false;
        }
    }

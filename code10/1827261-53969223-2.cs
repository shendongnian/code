    private static readonly ConcurrentDictionary<Type, bool> _memoized = 
        new ConcurrentDictionary<Type, bool>();
    public static bool IsUnmanaged(this Type type)
    {
        bool answer;
        // check if we already know the answer
        if (!_memoized.TryGetValue(type, out answer))
        {
            if (!type.IsValueType)
            {
                // not a struct -> false
                answer = false;
            }
            else if (type.IsPrimitive || type.IsPointer || type.IsEnum)
            {
                // primitive, pointer or enum -> true
                answer = true;
            }
            else
            {
                // otherwise check recursively
                answer = type
                    .GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
                    .All(f => IsUnmanaged(f.FieldType));
            }
            _memoized[type] = answer;
        }
        return answer;
    }

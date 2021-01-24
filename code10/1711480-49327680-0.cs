    public static class FluentAssertionsExtensions
    {
        /// <summary>
        /// Extends the functionality of <see cref="EquivalencyAssertionOptions{TExpectation}" />.ComparingByMembers by recursing into the entire object graph
        /// of the T or passed object and marks all property reference types as types that should be compared by its members even though it may override the
        /// System.Object.Equals(System.Object) method. T should be used in conjunction with RespectingDeclaredTypes. The passed object should be used in
        /// conjunction with RespectingRuntimeTypes.
        /// </summary>
        public static EquivalencyAssertionOptions<T> ComparingByMembersRecursive<T>(this EquivalencyAssertionOptions<T> options, object obj = null)
        {
            var handledTypes = new HashSet<Type>();
            var items = new Stack<(object obj, Type type)>(new[] { (obj, obj?.GetType() ?? typeof(T)) });
            while (items.Any())
            {
                (object obj, Type type) item = items.Pop();
                Type type = item.obj?.GetType() ?? item.type;
                if (!handledTypes.Contains(type))
                {
                    handledTypes.Add(type);
                    foreach (PropertyInfo pi in type.GetProperties())
                    {
                        object nextObject = item.obj != null ? pi.GetValue(item.obj) : null;
                        Type nextType = nextObject?.GetType() ?? pi.PropertyType;
                        // Skip string as it is essentially an array of chars, and needn't be processed.
                        if (nextType != typeof(string))
                        {
                            if (nextType.GetInterface(nameof(IEnumerable)) != null)
                            {
                                nextType = nextType.HasElementType ? nextType.GetElementType() : nextType.GetGenericArguments().First();
                                if (nextObject != null)
                                {
                                    // Look at all objects in a collection in case any derive from the collection element type.
                                    foreach (object enumObj in (IEnumerable)nextObject)
                                    {
                                        items.Push((enumObj, nextType));
                                    }
                                    continue;
                                }
                            }
                            items.Push((nextObject, nextType));
                        }
                    }
                    if (type.IsClass && type != typeof(string))
                    {
                        // ReSharper disable once PossibleNullReferenceException
                        options = (EquivalencyAssertionOptions<T>)options
                            .GetType()
                            .GetMethod(nameof(EquivalencyAssertionOptions<T>.ComparingByMembers))
                            .MakeGenericMethod(type).Invoke(options, null);
                    }
                }
            }
            return options;
        }
    }

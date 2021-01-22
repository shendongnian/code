    public static class QueryableExtensions {
        /// <summary>
        /// Constructs a query that only selects the columns that are actually in the type <typeparamref name="T"/> as public properties.
        /// 
        /// Useful for inherited types when you only want the base type information.
        /// </summary>
        /// <remarks>
        /// This function materializes the query. You'll want to call the where clauses BEFORE this call (since it is an optimization).
        /// </remarks>
        /// <typeparam name="T">Entity type.</typeparam>
        /// <param name="query">Source query.</param>
        /// <returns>An IEnumerable of items of type <typeparamref name="T"/>.</returns>
        public static IEnumerable<T> FilterColumnsByType<T>(this IQueryable<T> query) where T : new() {
            Type type = typeof(T);
            List<string> selectedProps = type.GetProperties().Select(p => p.Name).ToList();
            Tuple<IQueryable, Type> anonObjectTypePair = query.SelectDynamicAndType(selectedProps);
            IQueryable anonObjects = anonObjectTypePair.Item1;
            Type anonType = anonObjectTypePair.Item2;
            return anonObjects.Cast<object>().AsEnumerable().Select(ob => {
                var ret = new T();
                selectedProps.ForEach(p =>
                    type.GetProperty(p).SetValue(ret, anonType.GetField(p).GetValue(ob)));
                return ret;
            });
        }
        /// <summary>
        /// Constructs a query that selects only the <paramref name="propNames"/> given and returns an <see cref="IQueryable"/> of dynamic objects with only the selected fields.
        /// 
        /// Also returns the type information of the dynamic objects.
        /// </summary>
        /// <param name="source">Source query.</param>
        /// <param name="propNames">The list of properties names to select.</param>
        /// <returns>A query of anonymous types defined by the supplied <paramref name="propNames"/> and the actual <see cref="Type"/> used to construct anonymous type.</returns>
        public static Tuple<IQueryable, Type> SelectDynamicAndType(this IQueryable source, IEnumerable<string> propNames) {
            Dictionary<string, PropertyInfo> sourceProperties = propNames.ToDictionary(name => name, name => source.ElementType.GetProperty(name));
            Type dynamicType = LinqRuntimeTypeBuilder.GetDynamicType(sourceProperties.Values);
            ParameterExpression sourceItem = Expression.Parameter(source.ElementType, "t");
            IEnumerable<MemberBinding> bindings = dynamicType.GetFields().Select(p => Expression.Bind(p, Expression.Property(sourceItem, sourceProperties[p.Name]))).OfType<MemberBinding>();
            Expression selector = Expression.Lambda(Expression.MemberInit(
                    Expression.New(dynamicType.GetConstructor(Type.EmptyTypes)), bindings), sourceItem);
            return Tuple.Create(source.Provider.CreateQuery(Expression.Call(typeof(Queryable), "Select", new Type[] { source.ElementType, dynamicType },
                                     Expression.Constant(source), selector)), dynamicType);
        }
        /// <summary>
        /// Constructs a query that selects only the <paramref name="propNames"/> given and returns an <see cref="IQueryable{dynamic}"/> of dynamic objects with only the selected fields.
        /// </summary>
        /// <param name="source">Source query.</param>
        /// <param name="propNames">The list of properties names to select.</param>
        /// <returns>A query of anonymous types defined by the supplied <paramref name="propNames"/>.</returns>
        public static IQueryable<dynamic> SelectDynamic(this IQueryable source, IEnumerable<string> propNames) {
            return source.SelectDynamicAndType(propNames).Item1.Cast<dynamic>();
        }
        static class LinqRuntimeTypeBuilder {
            private static AssemblyName assemblyName = new AssemblyName() { Name = "DynamicLinqTypes" };
            private static ModuleBuilder moduleBuilder = null;
            private static Dictionary<string, Type> builtTypes = new Dictionary<string, Type>();
            static LinqRuntimeTypeBuilder() {
                moduleBuilder = Thread.GetDomain().DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run).DefineDynamicModule(assemblyName.Name);
            }
            private static string GetTypeKey(Dictionary<string, Type> fields) {
                string key = string.Empty;
                foreach (var field in fields.OrderBy(kvp => kvp.Key).ThenBy(kvp => kvp.Value.Name))
                    key += field.Key + ";" + field.Value.Name + ";";
                return key;
            }
            private static Type GetDynamicType(Dictionary<string, Type> fields) {
                if (null == fields)
                    throw new ArgumentNullException("fields");
                if (0 == fields.Count)
                    throw new ArgumentOutOfRangeException("fields", "fields must have at least 1 field definition");
                try {
                    Monitor.Enter(builtTypes);
                    string className = GetTypeKey(fields);
                    if (builtTypes.ContainsKey(className))
                        return builtTypes[className];
                    TypeBuilder typeBuilder = moduleBuilder.DefineType(className, TypeAttributes.Public | TypeAttributes.Class | TypeAttributes.Serializable);
                    foreach (var field in fields)
                        typeBuilder.DefineField(field.Key, field.Value, FieldAttributes.Public);
                    builtTypes[className] = typeBuilder.CreateType();
                    return builtTypes[className];
                } catch (Exception ex) {
                    //log.Error(ex);
                    Console.WriteLine(ex);
                } finally {
                    Monitor.Exit(builtTypes);
                }
                return null;
            }
            public static Type GetDynamicType(IEnumerable<PropertyInfo> fields) {
                return GetDynamicType(fields.ToDictionary(f => f.Name, f => f.PropertyType));
            }
        }
    }

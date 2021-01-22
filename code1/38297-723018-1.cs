    public static IQueryable SelectDynamic(this IQueryable source, IEnumerable<string> fieldNames)
    {
        Dictionary<string, PropertyInfo> sourceProperties = fieldNames.ToDictionary(name => name, name => source.ElementType.GetProperty(name));
        Type dynamicType = LinqRuntimeTypeBuilder.GetDynamicType(sourceProperties.Values);
        ParameterExpression sourceItem = Expression.Parameter(source.ElementType, "t");
        IEnumerable<MemberBinding> bindings = dynamicType.GetFields().Select(p => Expression.Bind(p, Expression.Property(sourceItem, sourceProperties[p.Name]))).OfType<MemberBinding>();
        Expression selector = Expression.Lambda(Expression.MemberInit(
            Expression.New(dynamicType.GetConstructor(Type.EmptyTypes)), bindings), sourceItem);
        return source.Provider.CreateQuery(Expression.Call(typeof(Queryable), "Select", new Type[] { source.ElementType, dynamicType },
                     Expression.Constant(source), selector));
    }
    public static class LinqRuntimeTypeBuilder
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static AssemblyName assemblyName = new AssemblyName() { Name = "DynamicLinqTypes" };
        private static ModuleBuilder moduleBuilder = null;
        private static Dictionary<string, Type> builtTypes = new Dictionary<string, Type>();
        static LinqRuntimeTypeBuilder()
        {
            moduleBuilder = Thread.GetDomain().DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run).DefineDynamicModule(assemblyName.Name);
        }
        private static string GetTypeKey(Dictionary<string, Type> fields)
        {
            //TODO: optimize the type caching -- if fields are simply reordered, that doesn't mean that they're actually different types, so this needs to be smarter
            string key = string.Empty;
            foreach (var field in fields)
                key += field.Key + ";" + field.Value.Name + ";";
            return key;
        }
        public static Type GetDynamicType(Dictionary<string, Type> fields)
        {
            if (null == fields)
                throw new ArgumentNullException("fields");
            if (0 == fields.Count)
                throw new ArgumentOutOfRangeException("fields", "fields must have at least 1 field definition");
            try
            {
                Monitor.Enter(builtTypes);
                string className = GetTypeKey(fields);
                if (builtTypes.ContainsKey(className))
                    return builtTypes[className];
                TypeBuilder typeBuilder = moduleBuilder.DefineType(className, TypeAttributes.Public | TypeAttributes.Class | TypeAttributes.Serializable);
                foreach (var field in fields)                    
                    typeBuilder.DefineField(field.Key, field.Value, FieldAttributes.Public);
                builtTypes[className] = typeBuilder.CreateType();
                return builtTypes[className];
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            finally
            {
                Monitor.Exit(builtTypes);
            }
            return null;
        }
        private static string GetTypeKey(IEnumerable<PropertyInfo> fields)
        {
            return GetTypeKey(fields.ToDictionary(f => f.Name, f => f.PropertyType));
        }
        public static Type GetDynamicType(IEnumerable<PropertyInfo> fields)
        {
            return GetDynamicType(fields.ToDictionary(f => f.Name, f => f.PropertyType));
        }
    }

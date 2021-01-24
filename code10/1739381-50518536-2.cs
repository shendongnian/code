    public interface IXmlSerializerFactory
    {
        XmlSerializer CreateSerializer(Type rootType);
    }
    public static class AListSerializerFactory
    {
        static readonly XmlArrayItemTypeOverrideSerializerFactory instance;
        static AListSerializerFactory()
        {
            // Include here a list of all types that have a List<A> property.
            // You could use reflection to find all such public types in your assemblies.
            var declaringTypeList = new []
            {
                typeof(AListObject),
            };
            // Include here a list of all base types with a corresponding mapping 
            // to find all derived types in runtime.   Here you could use reflection
            // to find all such types in your assemblies, as shown in 
            // https://stackoverflow.com/questions/857705/get-all-derived-types-of-a-type
            var derivedTypesList = new Dictionary<Type,  Func<IEnumerable<Type>>>
            {
                { typeof(A), () => new [] { typeof(B), typeof(C) } },
            };
            instance = new XmlArrayItemTypeOverrideSerializerFactory(declaringTypeList, derivedTypesList);
        }
        public static IXmlSerializerFactory Instance { get { return instance; } }
    }
    public class XmlArrayItemTypeOverrideSerializerFactory : IXmlSerializerFactory
    {
        // To avoid a memory & resource leak, the serializers must be cached as explained in
        // https://stackoverflow.com/questions/23897145/memory-leak-using-streamreader-and-xmlserializer
        readonly object padlock = new object();
        readonly Dictionary<Type, XmlSerializer> serializers = new Dictionary<Type, XmlSerializer>();
        readonly XmlAttributeOverrides overrides;
        public XmlArrayItemTypeOverrideSerializerFactory(IEnumerable<Type> declaringTypeList, IEnumerable<KeyValuePair<Type, Func<IEnumerable<Type>>>> derivedTypesList)
        {
            var completed = new HashSet<Type>();
            overrides = declaringTypeList
                .SelectMany(d => derivedTypesList.Select(p => new { declaringType = d, itemType = p.Key, derivedTypes = p.Value() }))
                .Aggregate(new XmlAttributeOverrides(), (a, d) => a.AddXmlArrayItemTypes(d.declaringType, d.itemType, d.derivedTypes, completed));
        }
        public XmlSerializer CreateSerializer(Type rootType)
        {
            lock (padlock)
            {
                XmlSerializer serializer;
                if (!serializers.TryGetValue(rootType, out serializer))
                    serializers[rootType] = serializer = new XmlSerializer(rootType, overrides);
                return serializer;
            }
        }
    }
    public static partial class XmlAttributeOverridesExtensions
    {
        public static XmlAttributeOverrides AddXmlArrayItemTypes(this XmlAttributeOverrides overrides, Type declaringType, Type itemType, IEnumerable<Type> derivedTypes)
        {
            return overrides.AddXmlArrayItemTypes(declaringType, itemType, derivedTypes, new HashSet<Type>());
        }
        public static XmlAttributeOverrides AddXmlArrayItemTypes(this XmlAttributeOverrides overrides, Type declaringType, Type itemType, IEnumerable<Type> derivedTypes, HashSet<Type> completedTypes)
        {
            if (overrides == null || declaringType == null || itemType == null || derivedTypes == null || completedTypes == null)
                throw new ArgumentNullException();
            XmlAttributes attributes = null;
            for (; declaringType != null && declaringType != typeof(object); declaringType = declaringType.BaseType)
            {
                // Avoid duplicate overrides.
                if (!completedTypes.Add(declaringType))
                    break;
                foreach (var property in declaringType.GetProperties(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance))
                {
                    // Skip the property if already ignored
                    if (property.IsDefined(typeof(XmlIgnoreAttribute), false))
                        continue;
                    
                    // See if it is a list property, and if so, get its type.
                    var propertyItemType = property.PropertyType.GetListType();
                    if (propertyItemType == null)
                        continue;
                    // OK, its a List<itemType>.  Add all the necessary XmlElementAttribute declarations.
                    if (propertyItemType == itemType)
                    {
                        if (attributes == null)
                        {
                            attributes = new XmlAttributes();
                            foreach (var derivedType in derivedTypes)
                                // Here we are assuming all the derived types have unique XML type names.
                                attributes.XmlArrayItems.Add(new XmlArrayItemAttribute { Type = derivedType });
                            if (itemType.IsConcreteType())
                                attributes.XmlArrayItems.Add(new XmlArrayItemAttribute { Type = itemType });
                        }
                        overrides.Add(declaringType, property.Name, attributes);
                    }
                }
            }
            return overrides;
        }
    }
    public static class TypeExtensions
    {
        public static bool IsConcreteType(this Type type)
        {
            return !type.IsAbstract && !type.IsInterface;
        }
        public static Type GetListType(this Type type)
        {
            while (type != null)
            {
                if (type.IsGenericType)
                {
                    var genType = type.GetGenericTypeDefinition();
                    if (genType == typeof(List<>))
                        return type.GetGenericArguments()[0];
                }
                type = type.BaseType;
            }
            return null;
        }
    }

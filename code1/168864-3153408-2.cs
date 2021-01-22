    public static class KnownTypeHelper
    {
        public static IEnumerable<Type> GetServiceKnownTypes(ICustomAttributeProvider provider)
        {
            List<Type> result = new List<Type>();
            ServiceKnownTypesSection serviceKnownTypes = (ServiceKnownTypesSection)ConfigurationManager.GetSection("serviceKnownTypes");
            DeclaredServiceElement service = serviceKnownTypes.Services[((Type)(provider)).AssemblyQualifiedName];
            foreach (ServiceKnownTypeElement knownType in service.KnownTypes)
            {
                result.Add(knownType.Type);
            }
            return result;
        }
    }

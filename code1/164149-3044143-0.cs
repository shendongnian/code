    [ServiceKnownType("RegisterKnownTypes", typeof(Services))]
    public class Services : IServices
    {
        static public IEnumerable<Type> RegisterKnownTypes(ICustomAttributeProvider provider)
        {
        }
    }

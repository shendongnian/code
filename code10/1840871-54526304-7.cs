    public class PolicyProvider : IPolicyProvider
    {
        // constructor and container injection...
        public List<T> GetPolicies<T>(Type entityType)
        {
            var results = new List<T>();
            var currentType = entityType;
            var serviceInterfaceGeneric = typeof(T).GetGenericDefinition();
            while(true)
            {
                var currentServiceInterface = serviceInterfaceGeneric.MakeGenericType(currentType);
                var currentService = container.GetService(currentServiceInterface);
                if(currentService != null)
                {
                    results.Add(currentService)
                }
                currentType = currentType.BaseType;
                if(currentType == null)
                {
                    break;
                }
            }
            return results;
        }
    }

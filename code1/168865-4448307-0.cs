    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Reflection;
    /// <summary>
    /// Helper for finding the known types for Wcf Services from a configuration file.
    /// </summary>
    public static class KnownTypeHelper
    {
        /// <summary>
        /// Gets the known types for the service from a configuration file.
        /// </summary>
        /// <param name="provider">
        /// The provider.
        /// </param>
        /// <returns>
        /// The known types for the service from a configuration file.
        /// </returns>
        public static IEnumerable<Type> GetServiceKnownTypes(ICustomAttributeProvider provider)
        {
            var result = new List<Type>();
            var serviceKnownTypes = (ServiceKnownTypesSection)ConfigurationManager.GetSection("serviceKnownTypes");
            if (serviceKnownTypes != null)
            {
                var service = serviceKnownTypes.Services[((Type)provider).AssemblyQualifiedName];
                if (service != null)
                {
                    foreach (ServiceKnownTypeElement knownType in service.KnownTypes)
                    {
                        result.Add(knownType.Type);
                    }
                }
            }
            return result;
        }
    }

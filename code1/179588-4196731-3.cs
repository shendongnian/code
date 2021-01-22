    using System.Linq;
    using System.Reflection;
    using AutoMapper;
    
    public static class TypeMapExtensions
    {
        public static MemberInfo[] TryGetSourceProperties(this TypeMap @this, string propertyName)
        {
            if (@this != null)
            {
                var propertyMap = @this.GetPropertyMaps()
                    .Where(p => p.DestinationProperty.Name == propertyName).FirstOrDefault();
    
                if (propertyMap != null)
                {
                    var sourceProperties = propertyMap.GetSourceValueResolvers().OfType<IMemberGetter>();
                    if (sourceProperties.Any())
                        return sourceProperties.Select(x => x.MemberInfo).ToArray();
                }
            }
            return null;
        }
    
        /// <summary>
        /// Trys to retrieve a source property name, given a destination property name. Only handles simple property mappings, and flattened properties.
        /// </summary>
        public static string TryGetSourcePropertyName(this TypeMap @this, string propertyName)
        {
            var members = TryGetSourceProperties(@this, propertyName);
            return (members == null) ? null : string.Join(".", members.Select(x => x.Name).ToArray());
        }
    }

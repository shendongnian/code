    using System.Linq;
    using System.Reflection;
    using AutoMapper;
    
    public static class TypeMapExtensions
    {
        public static MemberInfo[] TryGetSourceProperties(this TypeMap @this, string propertyName)
        {
            if (@this != null)
            {
                var sourceProperties = @this.GetPropertyMaps()
                    .Where(p => p.DestinationProperty.Name == propertyName).FirstOrDefault();
    
                if (sourceProperties != null)
                {
                    return sourceProperties.GetSourceValueResolvers().Cast<IMemberGetter>()
                        .Select(x => x.MemberInfo).ToArray();
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
            return members == null ? null :
                members.Aggregate(string.Empty, (current, memberInfo) =>
                    current + ((current == string.Empty) ? memberInfo.Name : "." + memberInfo.Name));
        }
    }

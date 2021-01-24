    public class AuthorizedPropertyContractResolver : DefaultContractResolver
    {
        public AuthorizedPropertyContractResolver(ClaimsPrincipal user)
        {
            User = user;
        }
    
        public ClaimsPrincipal User { get; }
    
        protected override JsonProperty CreateProperty(MemberInfo member, 
            MemberSerialization memberSerialization)
        {
            var result = base.CreateProperty(member, memberSerialization);
            result.ShouldSerialize = e =>
            {
                var role = member.GetCustomAttribute<AuthorizePropertyAttribute>()?.Role;
                return string.IsNullOrWhiteSpace(role) ? true : User.IsInRole(role);
            };
            return result;
        }
    }

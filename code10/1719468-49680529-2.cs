    public class JsonViewContractResolver : JsonContractResolver {
        public JsonViewContractResolver(MediaTypeFormatter formatter) : base(formatter) {
        }
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization) {
            JsonProperty property = base.CreateProperty(member, memberSerialization);
            var viewAttr = member.GetCustomAttribute<JsonViewAttribute>();
            if (viewAttr != null) {
                // if decorated with attribute
                property.ShouldSerialize = (instance) => {
                    var context = HttpContext.Current;
                    if (context == null)
                        return true;
                    // we are in context of http request
                    if (context.User == null || context.User.Identity == null)
                        return false;
                    // should serialize only if user is in target role
                    return context.User.Identity.IsAuthenticated && context.User.IsInRole(viewAttr.ViewName);
                };
            }
            return property;
        }
    }

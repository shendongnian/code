    public class RoleBasedContractResolver : DefaultContractResolver
    {
        public IServiceProvider ServiceProvider { get; }
        public RoleBasedContractResolver( IServiceProvider sp)
        {
            this.ServiceProvider = sp;
        }
        
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var contextAccessor = this.ServiceProvider.GetRequiredService<IHttpContextAccessor>() ;
            var context = contextAccessor.HttpContext;
            var user = context.User;
            
           // if you're using the Identity, you can get the userManager :
           var userManager = context.RequestServices.GetRequiredService<UserManager<IdentityUser>>();
           // ...
        }
    }

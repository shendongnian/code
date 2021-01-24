    public class SessionFilter : IAsyncActionFilter {
        public async Task OnActionExecutionAsync(
            ActionExecutingContext context,
            ActionExecutionDelegate next) {
            // do something before the action executes
            var serviceProvider = context.HttpContext.RequestServices;    
            var sessionProvider = serviceProvider.GetService<SessionProvider>();
            var userManager = serviceProvider.GetService<MultiTenancyUserManager<ApplicationUser>>()
    
            var user = await userManager.GetUserAsync(context.HttpContext.User);    
            if (user != null) {
                sessionProvider.Initialise(user);
            }
            //execute action
            var resultContext = await next();
            // do something after the action executes; resultContext.Result will be set
            //...
        }
    }

    public class RequestTokenMiddleware
        {
            private readonly RequestDelegate _next;
            private readonly SignInManager<User> _signInManager;
    
            public RequestTokenMiddleware(RequestDelegate next, SignInManager<User> signInManager)
            {
                _next = next;
                _signInManager = signInManager;
            }
    
            public async Task Invoke(HttpContext context)
            {
                try
                {
                    await _next(context);
                }
                catch (Exception exc)
                {
                    signOut(context);
                }
            }
    
            private async void signOut(HttpContext context)
            {
                try
                {
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(ResultModel.Failure(null, ResultModel.StatusType.InvalidToken)));
                }
                catch (Exception)
                {
                    throw new Exception();
                }
            }
        }

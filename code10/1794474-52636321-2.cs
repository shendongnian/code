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
                    var hasAuthorization = context.Request.Headers.ContainsKey("Authorization");
                if (!hasAuthorization)
                {
                    await _next(context); 
                }
                else
                {
                    var shouldBeNext = false;
                    foreach (var item in context.Request.Headers)
                    {
                        if (item.Key == "Authorization")
                        {
                            using (var contextBudget = BudgetUnitOfWork.Get())
                            {
    
                                var tokenCode = item.Value.ToString().Remove(0, 7);
                                var token = await contextBudget.Db.Token.FirstOrDefaultAsync(x => x.TokenCode == tokenCode).ConfigureAwait(false);
                                if (token == null || !token.IsValid)
                                {
                                    signOut(context);
                                }
                                else
                                {
                                    shouldBeNext = true;
                                }
                            }
                        }
                    }
                    if (shouldBeNext)
                    {
                        await _next(context);
                    }
    
                }
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

                if (isInOneOfThisRole == false)
                {
                    if (principal.Identity.IsAuthenticated)
                    {
                        context.Result = new ForbidResult();
                    }
                    else
                    {
                        context.Result = new UnauthorizedResult();
                    }
                    
                    await context.Result.ExecuteResultAsync(context);
                }
                else
                {
                    await next();
                }

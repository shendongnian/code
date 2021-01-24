            if (AuthType.StartsWith("Basic"))
            {
                var handlers = Context.RequestServices.GetRequiredService<IAuthenticationHandlerProvider>();
                var handler = handlers.GetHandlerAsync(Context, BasicAuthenticationDefaults.AuthenticationScheme).Result;
                var res = handler.AuthenticateAsync().Result;
                Debug.WriteLine(res.Succeeded);
                if (res.Succeeded)                
                    return Task.FromResult(res);
                
            }
            else if(AuthType.StartsWith("Bearer"))
            {
                var handlers = Context.RequestServices.GetRequiredService<IAuthenticationHandlerProvider>();
                var handler = handlers.GetHandlerAsync(Context, JwtBearerDefaults.AuthenticationScheme).Result;
                var res = handler.AuthenticateAsync().Result;
                Debug.WriteLine(res.Succeeded);
                if (res.Succeeded)
                    return Task.FromResult(res);
            }

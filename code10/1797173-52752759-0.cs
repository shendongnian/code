    services.AddAuthentication()
    .AddJwtBearer(options =>{
        // options.TokenValidationParameters=  ...
        options.Events = new JwtBearerEvents() {
            OnMessageReceived= async (context) => {
                var tokenService = context.HttpContext.RequestServices.GetRequiredService<IOneTimeOnlyJwtTokenService>();
                if (context.Request.Headers.ContainsKey("Authorization") ){
                    var header = context.Request.Headers["Authorization"].FirstOrDefault();
                    if (header.StartsWith("Bearer",StringComparison.OrdinalIgnoreCase)){
                        var token = header.Substring("Bearer".Length).Trim();
                        context.Token = token;
                    }
                }
                if (context.Token == null) {
                    return;
                }
                if (await tokenService.HasBeenConsumed(context.Token))
                {
                    context.Fail("not a valid token");
                }
                else {
                    await tokenService.InvalidateToken(context.Token);
                }
            }
        };
    });

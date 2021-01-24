     o.Events = new JwtBearerEvents //For signalR
                    {
                        OnMessageReceived = context =>
                        {
                            if (context.HttpContext.WebSockets.IsWebSocketRequest || context.Request.Headers["Accept"] == "text/event-stream")
                            {
                                StringValues accessToken = context.Request.Query["token"];
                                if (!string.IsNullOrEmpty(accessToken))
                                    context.Token = accessToken;
                            }
                            return Task.CompletedTask;
                        }
                    };

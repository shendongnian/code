    options.Events.OnRedirectToIdentityProvider = redirectContext =>
                          {
                              if (redirectContext.Request.Path.StartsWithSegments("/api"))
                              {
                                  if (redirectContext.Response.StatusCode == (int)HttpStatusCode.OK)
                                  {
                                      redirectContext.ProtocolMessage.State = options.StateDataFormat.Protect(redirectContext.Properties);
                                      redirectContext.Response.StatusCode =   (int)HttpStatusCode.Unauthorized;
                                      redirectContext.Response.Headers["Location"] = redirectContext.ProtocolMessage.CreateAuthenticationRequestUrl();
                                  }
                                  redirectContext.HandleResponse();
                              }
                              return Task.CompletedTask;
                          };

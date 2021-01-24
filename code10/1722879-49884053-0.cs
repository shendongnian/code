    return new LoginViewModel
                {
                    EnableLocalLogin = false,
                    ReturnUrl = returnUrl,
                    Username = context.LoginHint,
                    ExternalProviders = new[] { new ExternalProvider { AuthenticationScheme = **context.IdP** } }
                };

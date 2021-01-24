    app.UseCookieAuthentication(new CookieAuthenticationOptions()
    {
        AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Active,
        LoginPath = Microsoft.Owin.PathString.FromUriComponent("/Account/SignIn"),
        TicketDataFormat = new CustomSecureDataFormat()
    });

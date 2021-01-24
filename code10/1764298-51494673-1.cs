    using Microsoft.Owin.Security.DataProtection; 
    using Microsoft.Owin.Security.DataHandler;
    IDataProtector dataProtecter = app.CreateDataProtector("YOUR_KEY");
    var ticketDataFormat = new TicketDataFormat(dataProtecter);
    new OAuthAuthorizationServerOptions
    {
        TicketDataFormat = ticketDataFormat
    };

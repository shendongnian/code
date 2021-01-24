    using System,
    using Microsoft.Exchange.Webservices.Data;
     
    ExchangeService exchange= new ExchangeService(ExchangeVersion.Exchange2007_SP1);
    exchange.Credentials = new WebCredentials("user1@contoso.com", "password ");
    exchange.AutodiscoverUrl("user1@contoso.com");;

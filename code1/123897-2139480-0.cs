    using Microsoft.Web.Services3;
    using Microsoft.Web.Services3.Security.Tokens;
    using Microsoft.Web.Services3.Security;
    .
    .
    .
    WS.FooResultHttpService ws = new WS.FooResultHttpService();
    ws.RequestSoapContext.Security.Tokens.Add(new UsernameToken("blah", "blah", PasswordOption.SendPlainText));

    var client = new SmtpClient();
    // Do not remove this using. In .NET 4.0 SmtpClient implements IDisposable.
    using (client as IDisposable)
    {
        client.Send(message);
    } 

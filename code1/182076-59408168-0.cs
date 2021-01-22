    SmtpSection section = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
    string from = section.From;
    string host = section.Network.Host;
    int port = section.Network.Port;
    bool enableSsl = section.Network.EnableSsl;
    string user = section.Network.UserName;
    string password = section.Network.Password;

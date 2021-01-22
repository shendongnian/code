    public static bool ValidateCredentials(string login, string password, string server, int port, bool enableSsl) {
            SmtpConnectorBase connector;
            if (enableSsl) {
                connector = new SmtpConnectorWithSsl(server, port);
            } else {
                connector = new SmtpConnectorWithoutSsl(server, port);
            }
            if (!connector.CheckResponse(220)) {
                return false;
            }
            connector.SendData($"HELO {Dns.GetHostName()}{SmtpConnectorBase.EOF}");
            if (!connector.CheckResponse(250)) {
                return false;
            }
            connector.SendData($"AUTH LOGIN{SmtpConnectorBase.EOF}");
            if (!connector.CheckResponse(334)) {
                return false;
            }
            connector.SendData(Convert.ToBase64String(Encoding.UTF8.GetBytes($"{login}")) + SmtpConnectorBase.EOF);
            if (!connector.CheckResponse(334)) {
                return false;
            }
            connector.SendData(Convert.ToBase64String(Encoding.UTF8.GetBytes($"{password}")) + SmtpConnectorBase.EOF);
            if (!connector.CheckResponse(235)) {
                return false;
            }
            return true;
        }

    public class EmailSender
    {
        private readonly SmtpClient _smtpServer;
        private readonly MailAddress _fromAddress;
        public EmailSender()
        {
            ServicePointManager.ServerCertificateValidationCallback = RemoteServerCertificateValidationCallback;
            _smtpServer = new SmtpClient();
        }
		public EmailSender(string smtpHost, int smtpPort, bool enableSsl, string userName, string password, string fromEmail, string fromName) : this()
        {
            _smtpServer.Host = smtpHost;
            _smtpServer.Port = smtpPort;
            _smtpServer.UseDefaultCredentials = false;
            _smtpServer.EnableSsl = enableSsl;
            _smtpServer.Credentials = new NetworkCredential(userName, password);
            _fromAddress = new MailAddress(fromEmail, fromName);
        }
        public bool Send(string address, string mailSubject, string htmlMessageBody,
            string fileName = null)
        {
            return Send(new List<MailAddress> { new MailAddress(address) }, mailSubject, htmlMessageBody, fileName);
        }
        public bool Send(List<MailAddress> addressList, string mailSubject, string htmlMessageBody,
            string fileName = null)
        {
            var mailMessage = new MailMessage();
            try
            {
				if (_fromAddress != null)
                    mailMessage.From = _fromAddress;
				
				foreach (var addr in addressList)
                    mailMessage.To.Add(addr);
                mailMessage.SubjectEncoding = Encoding.UTF8;
                mailMessage.Subject = mailSubject;
                mailMessage.Body = htmlMessageBody;
                mailMessage.BodyEncoding = Encoding.UTF8;
                mailMessage.IsBodyHtml = true;
                if ((fileName != null) && (System.IO.File.Exists(fileName)))
                {
                    var attach = new Attachment(fileName, MediaTypeNames.Application.Octet);
                    attach.ContentDisposition.CreationDate = System.IO.File.GetCreationTime(fileName);
                    attach.ContentDisposition.ModificationDate = System.IO.File.GetLastWriteTime(fileName);
                    attach.ContentDisposition.ReadDate = System.IO.File.GetLastAccessTime(fileName);
                    mailMessage.Attachments.Add(attach);
                }
                _smtpServer.Send(mailMessage);
            }
            catch (Exception e)
            {
                // TODO lor error
                return false;
            }
            return true;
        }
        public static bool RemoteServerCertificateValidationCallback(Object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
    {
        if (sslPolicyErrors == SslPolicyErrors.None)
            return true;
        // if got an cert auth error
        if (sslPolicyErrors != SslPolicyErrors.RemoteCertificateNameMismatch) return false;
        const string sertFileName = "smpthost.cer";
        // check if cert file exists
        if (File.Exists(sertFileName))
        {
            var actualCertificate = X509Certificate.CreateFromCertFile(sertFileName);
            return certificate.Equals(actualCertificate);
        }
        // export and check if cert not exists
        using (var file = File.Create(sertFileName))
        {
            var cert = certificate.Export(X509ContentType.Cert);
            file.Write(cert, 0, cert.Length);
        }
        var createdCertificate = X509Certificate.CreateFromCertFile(sertFileName);
        return certificate.Equals(createdCertificate);
    }
 }

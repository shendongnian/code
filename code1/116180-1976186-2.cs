    public enum MailAddressType
    {
        Sender,
        Recipient
    }
    public class MyMailAddressException : Exception
    {
        public MailAddressType AddressType { get; set; }
        public string EmailAddress { get; set; }
        public MyMailAddressException(
            string message,
            MailAddressType addressType,
            string emailAddress,
            Exception innerException) : base(message, innerException)
        {
            AddressType = addressType;
            EmailAddress = emailAddress;
        }
    }
    public void SendEmail(
        string senderEmail,
        string senderDisplayName,
        IEnumerable<string> recipientEmails,
        string subject,
        string message)
    {
        using (
            var mailMessage = new MailMessage
                              {
                                  Subject = subject, 
                                  Body = message
                              })
        {
            try
            {
                mailMessage.From = new MailAddress(
                    senderEmail, senderDisplayName);
            }
            catch (FormatException ex)
            {
                throw new MyMailAddressException(
                    "Invalid from address", MailAddressType.Sender,
                    senderEmail, ex);
            }
            foreach (var recipient in recipientEmails)
            {
                try
                {
                    mailMessage.To.Add(recipient);
                }
                catch (FormatException ex)
                {
                    throw new MyMailAddressException(
                        "Invalid to address", MailAddressType.Recipient,
                        recipient, ex);
                }
            }
            var smtpClient = new SmtpClient("192.168.168.182");
            smtpClient.Send(mailMessage);
        }
    }

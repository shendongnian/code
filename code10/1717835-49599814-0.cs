    using System.ComponentModel;
    using System.Net.Mail;
    using System.Net;
    using System.ComponentModel.DataAnnotations;
    
    namespace Hector.Framework.Controls
    {
        public class MailMessageControl : Component
        {
            private MailMessage Mail = new MailMessage();
            private SmtpClient SmtpClient = new SmtpClient();
    
            public MailMessageControl()
            {
                Host = "smtp.gmail.com";
                Port = 587;
                EnableSSL = true;
            }
    
            public string Host
            {
                get => SmtpClient.Host;
                set => SmtpClient.Host = value;
            }
    
            public int Port
            {
                get => SmtpClient.Port;
                set => SmtpClient.Port = value;
            }
    
            public bool EnableSSL
            {
                get => SmtpClient.EnableSsl;
                set => SmtpClient.EnableSsl = value;
            }
    
            public void AttachFile(string path)
            {
                Mail.Attachments.Add(new Attachment(path));
            }
    
            public void SetCredentials(string mail, string password)
            {
                SmtpClient.Credentials = new NetworkCredential(mail, password);
            }
    
            public void SetSender(string mail)
            {
                Mail.From = new MailAddress(mail);
            }
    
            public void AddAddressSee(string mail)
            {
                Mail.To.Add(mail);
            }
    
            public void SetSubject(string subject)
            {
                Mail.Subject = subject;
            }
    
            public void SetBody(string body, bool isHTML)
            {
                Mail.IsBodyHtml = isHTML;
                Mail.Body = body;
            }
    
            public bool SendEmail()
            {
                try
                {
                    SmtpClient.Send(Mail);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
    
            public bool IsValidEmail(string email)
            {
                try
                {
                    return new MailAddress(email).Address == email;
                }
                catch
                {
                    return false;
                }
            }
    
            public bool EmailIsValidated(string email)
            {
                return new EmailAddressAttribute().IsValid(email);
            }
        }
    }

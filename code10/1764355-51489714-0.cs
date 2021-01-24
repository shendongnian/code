    using System.Net;
    using System.Net.Mail;
    
    namespace ConsoleApp2
    {
        class Program
        {
            static void Main(string[] args)
            {
                var html = "<html><head><body><h1>hello world!</h1></body><head></html>";
                var from = "me@here.com";
                var to = "them@there.com";
    
                var msg = new MailMessage(from, to)
                {
                    Subject = "My Subject",
                    Body = html,
                    IsBodyHtml = true
                };
                SendGmail("myUserName", "myPassword", msg);
            }
    
            public static void SendGmail(string username, string password, MailMessage msg)
            {
                var client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Credentials = new NetworkCredential(username, password);
                client.Send(msg);
            }
        }
    }

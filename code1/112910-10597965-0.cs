    using System;
    using System.Windows.Forms;
    using System.Net;
    using System.Net.Mail;
    using System.Threading; 
    
    namespace ExceptionHandlerTest
    {
        static class Program
        {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                Application.ThreadException +=
                    new ThreadExceptionEventHandler(Application_ThreadException);
                // Your designer generated commands.
            }
    
            static void Application_ThreadException(object sender, ThreadExceptionEventArgs e) 
            {
    
                var fromAddress = new MailAddress("your Gmail address", "Your name");
                var toAddress = new MailAddress("email address where you want to receive reports", "Your name");
                const string fromPassword = "your password";
                const string subject = "exception report";
                Exception exception = e.Exception;
                string body = exception.Message + "\n" + exception.Data + "\n" + exception.StackTrace + "\n" + exception.Source;
    
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    //You can also use SendAsync method instead of Send so your application begin invoking instead of waiting for send mail to complete. SendAsync(MailMessage, Object) :- Sends the specified e-mail message to an SMTP server for delivery. This method does not block the calling thread and allows the caller to pass an object to the method that is invoked when the operation completes. 
                    smtp.Send(message);
                }
            }
        }
    }

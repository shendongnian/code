    using System;
    using System.Text;
    using System.Net.Mail;
    using System.Net;
    
    namespace TestingConsole
    {
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    string to = "to@domain.com";
                    string from = "from@gmail.com";
                    string from_pwd = "mypassword";
                    string subject = "Sample Mail testing";
                    string body = "Wow this is testing body";
                    MailMessage mM = new MailMessage();
                    mM.From = new MailAddress(from);
                    mM.To.Add(to);
                    mM.Subject = subject;
                    mM.Body = body;
                    mM.IsBodyHtml = false;
                    mM.Priority = MailPriority.High;
                    SmtpClient sC = new SmtpClient("smtp.gmail.com");
                    sC.Port = 587;
                    sC.Credentials = new NetworkCredential(from, from_pwd);
                    sC.EnableSsl = true;
                    sC.Send(mM);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + " " + e.StackTrace);
                }
            }
        }
    }

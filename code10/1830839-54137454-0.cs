    using System;
    using System.Net.Mail;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                using (SmtpClient client = new SmtpClient())
                {
                    client.Host = config.GetClientSMTP();
                    client.EnableSsl = true;
                    client.Port = 587;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new System.Net.NetworkCredential(config.GetClientEmail(), config.GetClientPassword());
    
                    using (MailMessage mail = new MailMessage())
                    {
                        mail.Sender = new MailAddress(config.GetClientEmail(), config.GetClientName());
                        mail.From = new MailAddress(config.GetClientEmail(), config.GetClientCompany());
                        mail.To.Add(new MailAddress(config.emailToReceive));
                        mail.Subject = "Test 2";
                        mail.Body = "Test 2";
                        var isSend = false;
                        try
                        {
                            client.Send(mail);
                            isSend = true;
                        }
                        catch (Exception ex)
                        {
                            isSend = false;
                            Console.WriteLine(ex.Message);
                        }
    
                        Console.WriteLine(isSend ? "All Greeen" : "Bad Day");
                        Console.ReadLine();
                    }
                }
    
            }
        }
    }

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Quartz;
    using Quartz.Listener;
    using System.Net;
    using System.Net.Mail;
    using System.Threading.Tasks;
    
    namespace WEB_Project.Models
    {
        public class EmailJob : IJob 
        {
            public Task Execute(IJobExecutionContext context)
            {
                using (var message = new MailMessage("user@gmail.com", "user@live.co.uk"))
                {
                    message.Subject = "Test";
                    message.Body = "Test at " + DateTime.Now;
                    using (SmtpClient client = new SmtpClient
                    {
                        EnableSsl = true,
                        Host = "smtp.gmail.com",
                        Port = 587,
                        Credentials = new NetworkCredential("user@gmail.com", "password")
                    })
                    {
                        client.Send(message);
                    }
                }
              return Task.CompletedTask;
            }
        }
    }

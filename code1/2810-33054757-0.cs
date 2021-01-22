    using System;
    using System.Net;
    using System.Net.Mail;
    
    namespace SendMailViaGmail
    {
       class Program
       {
       static void Main(string[] args)
       {
    
          //Specify senders gmail address
          string SendersAddress = "Sendersaddress@gmail.com";
          //Specify The Address You want to sent Email To(can be any valid email address)
          string ReceiversAddress = "ReceiversAddress@yahoo.com";
          //Specify The password of gmial account u are using to sent mail(pw of sender@gmail.com)
          const string SendersPassword = "Password";
          //Write the subject of ur mail
          const string subject = "Testing";
          //Write the contents of your mail
          const string body = "Hi This Is my Mail From Gmail";
    
          try
          {
            //we will use Smtp client which allows us to send email using SMTP Protocol
            //i have specified the properties of SmtpClient smtp within{}
            //gmails smtp server name is smtp.gmail.com and port number is 587
            SmtpClient smtp = new SmtpClient
            {
               Host = "smtp.gmail.com",
               Port = 587,
               EnableSsl = true,
               DeliveryMethod = SmtpDeliveryMethod.Network,
               Credentials = new NetworkCredential(SendersAddress, SendersPassword),
               Timeout = 3000
            };
    
            //MailMessage represents a mail message
            //it is 4 parameters(From,TO,subject,body)
    
            MailMessage message = new MailMessage(SendersAddress, ReceiversAddress, subject, body);
            /*WE use smtp sever we specified above to send the message(MailMessage message)*/
    
            smtp.Send(message);
            Console.WriteLine("Message Sent Successfully");
            Console.ReadKey();
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex.Message);
            Console.ReadKey();
         }
    }
    }
    }

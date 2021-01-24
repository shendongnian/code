    using System;
    using System.IO;
    using System.Net.Mail;
    
    namespace PayneInMyButt
    {
        public class EmailImage
        {
            public void DemoForImage()
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("TODO");
                    mail.To.Add("TODO");
                    mail.Subject = "This is an email";
    
                    AlternateView PlainMessage = AlternateView.CreateAlternateViewFromString("Hello, plain text", null, 
                        "text/plain");
    
                    AlternateView HtmlMessage = AlternateView.CreateAlternateViewFromString(
                        "This is an automated email, please do not respond<br><br>This is a test <br>" + 
                        "<span style=\"font-weight: bold; padding-left: 20px;padding-right:5px\">Some bold text</span>" + 
                        "Non bold<br><span style=\"font-weight: bold; padding-left: 5px;padding-right:5px\">Second line</span>" + 
                        "This is Kate below<br><span style=\"font-weight: bold; padding-left: 70px;padding-right:5px\">" + 
                        "<img src=cid:Image1>", null, "text/html");
    
                    LinkedResource Logo = new LinkedResource(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, 
                        "LogoImage.jpg"), 
                        "image/jpeg");
    
                    Logo.ContentId = "Image1";
    
                    mail.AlternateViews.Add(PlainMessage);
                    mail.AlternateViews.Add(HtmlMessage);
                    using (SmtpClient smtp = new SmtpClient("TODO"))
                    {
                        smtp.Send(mail);
                    }
                }
            }
        }
    }

        private void SendMail()
        {
            var mailMessage = new MailMessage("xxxxx@gmail.com", "yzolxxxxxotarev@gmail.com");
            mailMessage.Subject = "Tester ASP.NET Boat Inspector";
            mailMessage.Body = "This is the message";
            var contentPath = _env.ContentRootPath+@"\mytest.docx";
            
            Attachment data = new Attachment(contentPath, MediaTypeNames.Application.Octet);
            mailMessage.Attachments.Add(data);
            
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "xxxxx@gmail.com",
                Password = "xxxxx"
            };
            
            
            client.EnableSsl = true;
            client.Send(mailMessage);
        }

        public override void Write(byte[] buffer, int offset, int count) {
        // get the html
        string content= System.Text.Encoding.UTF8.GetString(buffer, offset, count);
    
       MailMessage mail = new MailMessage();  
      
       mail.From = new MailAddress("test@test.com");  
       mail.To.Add("steve@test.com");  
       mail.IsBodyHtml = true;  
      
       mail.Subject = "Test";  
       mail.Body = content;  
      
        SmtpClient smtp = new SmtpClient("1111");  
        smtp.Send(mail);  
    
        buffer = System.Text.Encoding.UTF8.GetBytes(HTML);
        this.Base.Write(buffer, 0, buffer.Length);    
        }

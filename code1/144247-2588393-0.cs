    void sendMail() {
       try{
          MailMessage mail = new MailMessage();
          mail.To.Add("abc@gmail.com");
          mail.From = new MailAddress("abc@gmail.com", txt_name.Text);
          mail.Subject = txt_subject.Text;
          mail.Body = txt_body.Text;
          SmtpClient smtp = new SmtpClient("smtp.gmail.com");
          smtp.EnableSsl = true;
          NetworkCredential yetki = new NetworkCredential("abc@gmail.com", "11111111");
          smtp.Credentials = yetki;
          smtp.Send(mail);
          Response.Write("mailiniz başarılı bir şekilde gönderilmiştir");
       }
       catch(Exception e){
          Response.Write(e.Message);
       }
    
    }

    for (var index= 0; index< students.Length; index++)
        {
            try
            {
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var smtpClient = new SmtpClient();
        
                var message = new MailMessage();
                message.To.Add(new MailAddress(students[index])); 
                message.Subject = "I'm interested in your project";
                message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
                message.IsBodyHtml = true;
        
                using (var smtp = new SmtpClient())
                {
                    await smtp.SendMailAsync(message);
                           }
            }
            catch (Exception ex)
            {
                //MessageBox("Your Email address is not valid");
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Your Email address is not valid');", true);
            }
        }
        
         return RedirectToAction("Sent");

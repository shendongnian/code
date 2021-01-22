             MailMessage mail = new MailMessage(from, to, subject, message);
             if(checkBox1.CheckState == CheckState.Checked )
               {
                   mail.IsBodyHtml = true;
               }
             SmtpClient client = new SmtpClient("localhost");
             client.Send(mail);

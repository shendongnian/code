     private async void sendButton_Click(object sender, EventArgs e)
            {
                var result = await SendMail();
                if (result)
                {
                    MessageBox.Show("Mail sent");
                }
            }
    
            private Task<bool> SendMail()
            {
                var task = Task.Run<bool>(() =>
                {
                    MailMessage msg = new MailMessage("sendermail@gmail.com", "recievermail@gmail.com", "Movies this month", "Hello this is a test mail");
                    msg.IsBodyHtml = false;
    
                    using(SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.UseDefaultCredentials = false;
                        NetworkCredential xre = new NetworkCredential("sendermail@gmail.com", "Password");
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.Credentials = xre;
                        smtp.EnableSsl = true;
                        smtp.Send(msg);
    
                        return true;
                    }
                   
                });
                return task;
            }

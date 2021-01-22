    using (System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage(this.From, this.To, this.Subject, this.Body))
    {
        message.IsBodyHtml = true; 
        using(System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(this.Server))
        {
            client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network; 
            try  
            { 
                client.Send(message); 
            }   
            catch(System.Exception ex)  
            { 
                System.Windows.Forms.MessageBox.Show(ex.ToString());               
            }
        }
    } 

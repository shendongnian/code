    try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Timeout = 100000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("your gmail id", "password");
                MailMessage msg = new MailMessage();
                msg.To.Add(textBoxTo.Text);
                msg.From = new MailAddress("your gmail id");
                msg.Subject = textBoxSubject.Text;
                msg.Body = textBoxMsg.Text;
                Attachment data = new Attachment(textBoxAttachment.Text);
                msg.Attachments.Add(data);
                client.Send(msg);
                MessageBox.Show("Successfully Sent Message.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
           }

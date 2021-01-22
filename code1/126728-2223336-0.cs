     MailMessage feedbackmail = new MailMessage(
                    "joe.bloggs@joebloggsland.co.uk",
                    "joe.bloggs@joebloggsland.co.uk",
                    "Subject",
                    e.NewValues.Values.ToString());
    
                SmtpClient client = new SmtpClient("SMTP");
                try
                {
                    client.Send(feedbackmail);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Email unable to be sent at this time", ex.ToString());
                }

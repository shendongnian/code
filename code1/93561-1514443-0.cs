    StringBuilder sb = new StringBuilder();
    using (StringWriter sw = new StringWriter(sb))
    {
        using (HtmlTextWriter htmlTW = new HtmlTextWriter(sw))
        {
            this.Render(htmlTW);
        }
        using (var message = new MailMessage
                             {
                                 From = new MailAddress("from@company.com"), 
                                 Subject = "This is an HTML Email", 
                                 Body = sw.ToString(), 
                                 IsBodyHtml = true
                             })
        {
            message.To.Add("toaddress1@company.com,toaddress2@company.com");
            SmtpClient client = new SmtpClient();
            client.Send(message);
        }
    }

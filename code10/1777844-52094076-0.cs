    //create a new memorystream for the excel file
    MemoryStream ms;
    
    //create a new ExcelPackage
    using (ExcelPackage package = new ExcelPackage())
    {
        //create the WorkSheet
        ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet 1");
    
        //add some dummy data, note that row and column indexes start at 1
        Random rnd = new Random();
    
        for (int i = 1; i <= 3; i++)
        {
            for (int j = 1; j <= 27; j++)
            {
                worksheet.Cells[i, j].Value = rnd.Next(1, 25);
                worksheet.Cells[1, j].Value = DateTime.Now.ToString();
                worksheet.Cells[4, j].Value = "val " + rnd.Next(1, 25);
            }
        }
    
        //save the excel to the stream
        ms = new MemoryStream(package.GetAsByteArray());
    }
    
    //create a new mail message 
    using (SmtpClient client = new SmtpClient())
    using (MailMessage mail = new MailMessage())
    {
        client.Host = "mail.server.com";
        client.Port = 25;
        client.Timeout = 10000;
        client.EnableSsl = false;
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.UseDefaultCredentials = false;
        client.Credentials = new NetworkCredential("UserName", "PassWord");
    
        mail.From = new MailAddress("fake@falsesender.com", "gbubemi smith");
        mail.To.Add(new MailAddress("fake@falsereciever.com"));
        mail.Subject = "Send excel email attachment c#";
        mail.IsBodyHtml = true;
        mail.Body = "<html><head></head><body>Attached is the Excel sheet.</body></html>";
    
        //attach the excel file to the message
        mail.Attachments.Add(new Attachment(ms, "ExcelSheet1.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"));
    
        //send the mail
        try
        {
            client.Send(mail);
        }
        catch (Exception ex)
        {
            //handle error
        }
    }
    
    //cleanup the memorystream
    ms.Dispose();

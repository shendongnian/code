    protected void btnKaydet_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.openxmlformatsofficedocument.wordprocessingml.documet";
        Response.AddHeader("Content-Disposition", "attachment; filename=XXXX.doc");
        Response.ContentEncoding = Encoding.GetEncoding("ISO-8859-9");
        Response.Charset = "ISO-8859-9";
        EnableViewState = false;
        StringWriter writer = new StringWriter();
        HtmlTextWriter html = new HtmlTextWriter(writer);
        form1.RenderControl(html);
        byte[] bytesInStream = Encoding.GetEncoding("iso-8859-9").GetBytes(writer.ToString());
        MemoryStream memoryStream = new MemoryStream(bytesInStream);
        string msgBody = "";
        string Email = "mail@xxxxxx.org";
        SmtpClient client = new SmtpClient("mail.xxxxx.org");
        MailMessage message = new MailMessage(Email, "mail@someone.com", "ONLINE APP FORM WITH WORD DOC", msgBody);
        Attachment att = new Attachment(memoryStream, "XXXX.doc", "application/vnd.openxmlformatsofficedocument.wordprocessingml.documet");
        message.Attachments.Add(att);
        message.BodyEncoding = System.Text.Encoding.UTF8;
        message.IsBodyHtml = true;
        client.Send(message);}

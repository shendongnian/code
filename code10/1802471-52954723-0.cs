    using (MemoryStream ms = new MemoryStream())
    {
        var pdf = PdfGenerator.GeneratePdf(html, PdfSharp.PageSize.Letter);
        pdf.Save(ms, false);
    
        EmailMessage em = new EmailMessage();
        em.EmailFormat = EmailFormatEnum.Html;
        em.From = "no-reply@foo.com";
        em.Recipients = "foo.bar@baz.net";
        em.Subject = "Attachment Name";
        em.Body = "There is an attachment.";
    
        var attachment = new EmailAttachment(ms, "foo.pdf");
        em.Attachments.Add(attachment);
    
        // default sendImmediately of false
        EmailSender.SendEmail(SiteContext.CurrentSiteName, em);
    }

    MemoryStream ms = new MemoryStream();
    try
    {
        var pdf = PdfGenerator.GeneratePdf(html, PdfSharp.PageSize.A4);
        pdf.Save(ms, false);
    
        EmailMessage em = new EmailMessage();
        em.EmailFormat = EmailFormatEnum.Html;
        em.From = "no-reply@foo.com";
        em.Recipients = "foo.bar@baz.net";
        em.Subject = "Attachment Name";
        em.Body = "There is an attachment";
    
        var attachment = new EmailAttachment(ms, "foo.pdf");
        em.Attachments.Add(attachment);
    
        EmailSender.SendEmail(SiteContext.CurrentSiteName, em, true);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
    ms.Dispose();
    }

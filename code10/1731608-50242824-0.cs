    using Microsoft.Office.Interop.Outlook;
    Microsoft.Office.Interop.Outlook.Application application = new Microsoft.Office.Interop.Outlook.Application();    
    MailItem mail = application.CreateItemFromTemplate("oldfile.oft") as MailItem;
    mail.BodyFormat = OlBodyFormat.olFormatHTML;
    mail.Subject = "New Subject";
    mail.HTMLBody = "<p>This is a new <strong>OFT</strong> file with a changed subject line.</p>";
    mail.SaveAs("newfile.oft");

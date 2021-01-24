    foreach (XmlNode node in nodeList)
    {
        string CustomerName = node.SelectSingleNode("CustomerName").InnerText;
    
        string ReportName = node.SelectSingleNode("ReportName").InnerText + ".pdf";
    
        Outlook.Application mailApplication = new Outlook.Application();
    
        Outlook.MailItem mail = mailApplication.CreateItemFromTemplate(@"d:\Friday Report\#TEMPLATES\template.oft") as Outlook.MailItem;
        mail.BodyFormat = Outlook.OlBodyFormat.olFormatHTML;
        mail.Attachments.Add(@"d:\Friday Report\" + ReportName);
        mail.Subject = "Application Packaging – Weekly Summary";
        CustomerName = "<b>" + CustomerName + "</b> ";
        string body = mail.Body;
        string new_body = body.Replace("CustomerName", CustomerName );
        mail.HTMLBody = new_body;
        mail.Display(true);
        mail.Close(Outlook.OlInspectorClose.olDiscard);
    }

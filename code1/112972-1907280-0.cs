    Microsoft.Office.Interop.Outlook.Application app = new Microsoft.Office.Interop.Outlook.Application();
    
    var item = app.Session.OpenSharedItem("C:\\test.msg") as Microsoft.Office.Interop.Outlook.MailItem;
    string body = item.HTMLBody;
    int att = item.Attachments.Count;

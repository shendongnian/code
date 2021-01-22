    Microsoft.Office.Interop.Outlook.Application app = null;
    Microsoft.Office.Interop.Outlook.NameSpace session = null;
    Microsoft.Office.Interop.Outlook.MailItem item = null;
    try {
        app = new Microsoft.Office.Interop.Outlook.Application();
        session = app.Session;
        item = session.OpenSharedItem("C:\\test.msg") as Microsoft.Office.Interop.Outlook.MailItem;
        string body = item.HTMLBody;
        int att = item.Attachments.Count;
        (item as Microsoft.Office.Interop.Outlook._MailItem).Close(Microsoft.Office.Interop.Outlook.OlInspectorClose.olDiscard);
        (app as Microsoft.Office.Interop.Outlook._Application).Quit();
    } finally {
        if(item != null) {
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(item);
        }
        if(session != null) {
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(session);
        }
        if(app != null) {
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(app);
        }
    }

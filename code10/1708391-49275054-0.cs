    using System.Runtime.InteropServices;
    using Outlook = Microsoft.Office.Interop.Outlook;
  
    private void Reply(Outlook._MailItem mailItem)
    {
        Outlook.Actions actions = mailItem.Actions;
        Outlook.Action action = actions["Reply"];
        Marshal.ReleaseComObject(actions);
        action.ReplyStyle = Outlook.OlActionReplyStyle.olIncludeOriginalText;
        Outlook._MailItem response = action.Execute() as Outlook.MailItem;
        Marshal.ReleaseComObject(action);
        response.Display();
        Marshal.ReleaseComObject(response);
    }

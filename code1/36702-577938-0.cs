    // Dumps all email in Outlook to console window.
    // Prompts user with warning that an application is attempting to read Outlook data.
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Outlook = Microsoft.Office.Interop.Outlook;
    namespace OutlookEmail
    {
    class Program
    {
        static void Main(string[] args)
        {
            Outlook.Application app = new Outlook.Application();
            Outlook.NameSpace outlookNs = app.GetNamespace("MAPI");
            Outlook.MAPIFolder emailFolder = outlookNs.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderInbox);
            foreach (Outlook.MailItem item in emailFolder.Items)
            {
                Console.WriteLine(item.SenderEmailAddress + " " + item.Subject + "\n" + item.Body);
            }
            Console.ReadKey();
        }
    }
    }

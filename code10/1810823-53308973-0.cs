    using System;
    using System.Collections.Generic;
    using Outlook = Microsoft.Office.Interop.Outlook;
       public static class OutlookMailF
        {
            public static Outlook.ApplicationClass application = new Outlook.ApplicationClass();
            static Outlook.NameSpace nameSpace = application.GetNamespace("MAPI");
            static Outlook.MAPIFolder inbox = nameSpace.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);
            static Outlook.MAPIFolder sent = nameSpace.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderSentMail);
    
        public static List<Outlook.MailItem> GetInbox()
        {
            List<Outlook.MailItem> allMails = new List<Outlook.MailItem>();
            //inbox u tüm maillere ekle.
            foreach (object item in inbox.Items)
            {
                if (item is Outlook.MailItem)
                {
                    allMails.Add(item as Outlook.MailItem);
                }
            }
        }
    }

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Outlook = Microsoft.Office.Interop.Outlook;
    namespace outlook
    {
        class Program
        {
            static void Main(string[] args)
            {
                Outlook.Application oApp = new Outlook.Application();
                Outlook.NameSpace oNS = oApp.GetNamespace("mapi");
                oNS.Logon("appsystemacc", "App@12345", false, false);
                // this is how you set those properties from the session
                var EntryID = oApp.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox).EntryID;
                var StoreID = oApp.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox).StoreID;
    
                var folderID = oNS.GetFolderFromID(EntryID, StoreID);
            }
        }
    }

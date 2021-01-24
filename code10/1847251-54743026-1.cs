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
    
                // THE FOLDER YOU WISH TO FIND
                Outlook.MAPIFolder MySomeValueFolder = null;
                // USE THIS TO INDICATE IF FOUND
                bool IsFound = false;
    
                Microsoft.Office.Interop.Outlook._Folders oFolders;
                Microsoft.Office.Interop.Outlook.MAPIFolder oPublicFolder =
                    oNS.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderInbox).Parent;
                // Folders at Inbox level
                oFolders = oPublicFolder.Folders;
                foreach (Microsoft.Office.Interop.Outlook.MAPIFolder Folder in oFolders)
                {
                    // OPTIONAL:
                    // if(Folder.Name == "somevalue") { ... }
                    if (Folder.EntryID == "someValue")
                    {
                        Console.Write(Folder.Name + " " + Folder.StoreID);
                        MySomeValueFolder = Folder;
                        IsFound = true;
                    }     
                }
    
                if (IsFound)
                {
                    // now do with MySomeValueFolder whatever you want
                }
    
                Console.ReadLine();
            }
        }
    }

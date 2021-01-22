    using Microsoft.Office.Interop.Outlook;
    using System;
    using System.Collections.Generic;
    using System.Text;
    
    namespace ExportOutlookContacts
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                Items OutlookItems;
                Application outlookObj;
                MAPIFolder Folder_Contacts;
    
                outlookObj = new Application();
                Folder_Contacts = outlookObj.Session.GetDefaultFolder(OlDefaultFolders.olFolderContacts);
                OutlookItems = Folder_Contacts.Items;
    
                for (int i = 0; i < OutlookItems.Count; i++)
                {
                    ContactItem contact = (ContactItem)OutlookItems[i + 1];
                    Console.WriteLine(contact.FullName);
                    // https://msdn.microsoft.com/en-us/library/microsoft.office.interop.outlook.olsaveastype.aspx
                    contact.SaveAs(string.Format(@"C:\TEMP\Contacts\{0}.vcf", contact.FullName), 6);
                }
    
                Console.WriteLine("Done!");
                Console.ReadLine();
            }
        }
    }

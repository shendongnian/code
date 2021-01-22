    using System;
    using Outlook = Microsoft.Office.Interop.Outlook;
    
    namespace OutlookTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                Outlook.Application olApplication = new Outlook.Application();
    
                // get nameSpace and logon.
                Outlook.NameSpace olNameSpace = olApplication.GetNamespace("mapi");
                olNameSpace.Logon("Outlook", "", false, true);
    
                // get the contact items
                Outlook.MAPIFolder _olContacts = olNameSpace.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderContacts);
                Outlook.Items olItems = _olContacts.Items;
    
                foreach (object o in olItems)
                {
                    if (o is Outlook.ContactItem)
                    {
                        Outlook.ContactItem contact = (Outlook.ContactItem)o;
                        foreach (Outlook.ItemProperty property in contact.ItemProperties)
                        {
                            Console.WriteLine(property.Name + ": " + property.Value.ToString());
                        }
                    }
                }
                Console.WriteLine("Press any key");
                Console.ReadKey();
            }
        }
    }

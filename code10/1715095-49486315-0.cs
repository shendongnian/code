         Outlook.NameSpace outlookNameSpace;
         Outlook.MAPIFolder inbox;
         Outlook.Items items;
            private void ThisAddIn_Startup(object sender, System.EventArgs e)
            {
                outlookNameSpace = this.Application.GetNamespace("MAPI");
                inbox = outlookNameSpace.GetDefaultFolder(
                        Microsoft.Office.Interop.Outlook.
                        OlDefaultFolders.olFolderInbox);
                items = inbox.Items;
                items.ItemAdd +=
                    new Outlook.ItemsEvents_ItemAddEventHandler(items_ItemAdd);
            }
            void items_ItemAdd(object Item)
            {
                string filter = "USED CARS";
                Outlook.MailItem mail = (Outlook.MailItem)Item;
                if (Item != null)
                {
                    if (mail.MessageClass == "IPM.Note" &&
                               mail.Subject.ToUpper().Contains(filter.ToUpper()))
                    {
                        mail.Move(outlookNameSpace.GetDefaultFolder(
                            Microsoft.Office.Interop.Outlook.
                            OlDefaultFolders.olFolderJunk));
                    }
                }
            }

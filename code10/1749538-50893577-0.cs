    void DemoConversation()
    {
       object selectedItem = Application.ActiveExplorer().Selection[1];
       // For this example, you will work only with 
       //MailItem. Other item types such as
       //MeetingItem and PostItem can participate 
       //in Conversation.
       if (selectedItem is Outlook.MailItem)
       {
          // Cast selectedItem to MailItem.
          Outlook.MailItem mailItem = selectedItem as Outlook.MailItem; 
          // Determine store of mailItem.
          Outlook.Folder folder = mailItem.Parent as Outlook.Folder;
          Outlook.Store store = folder.Store;
          if (store.IsConversationEnabled == true)
          {
             // Obtain a Conversation object.
             Outlook.Conversation conv = mailItem.GetConversation();
             // Check for null Conversation.
             if (conv != null)
             {
                // Obtain Table that contains rows 
                // for each item in Conversation.
                Outlook.Table table = conv.GetTable();
                Debug.WriteLine("Conversation Items Count: " +                   table.GetRowCount().ToString());
                Debug.WriteLine("Conversation Items from Table:");
                while (!table.EndOfTable)
                {
                    Outlook.Row nextRow = table.GetNextRow();
                    Debug.WriteLine(nextRow["Subject"]
                        + " Modified: "
                        + nextRow["LastModificationTime"]);
                }
                Debug.WriteLine("Conversation Items from Root:");
                // Obtain root items and enumerate Conversation.
                Outlook.SimpleItems simpleItems = conv.GetRootItems();
                foreach (object item in simpleItems)
                {
                    // In this example, enumerate only MailItem type.
                    // Other types such as PostItem or MeetingItem
                    // can appear in Conversation.
                    if (item is Outlook.MailItem)
                    {
                        Outlook.MailItem mail = item as Outlook.MailItem;
                        Outlook.Folder inFolder = mail.Parent as Outlook.Folder;
                        string msg = mail.Subject 
                            + " in folder " + inFolder.Name;
                        Debug.WriteLine(msg);
                    }
                    // Call EnumerateConversation 
                    // to access child nodes of root items.
                    EnumerateConversation(item, conv);
                 }
              }
           }
        }
     }
     void EnumerateConversation(object item, Outlook.Conversation conversation)
     {
        Outlook.SimpleItems items = conversation.GetChildren(item);
        if (items.Count > 0)
        {
          foreach (object myItem in items)
          {
            // In this example, enumerate only MailItem type.
            // Other types such as PostItem or MeetingItem
            // can appear in Conversation.
            if (myItem is Outlook.MailItem)
            {
               Outlook.MailItem mailItem = myItem as Outlook.MailItem;
                Outlook.Folder inFolder = mailItem.Parent as Outlook.Folder;
                string msg = mailItem.Subject
                    + " in folder " + inFolder.Name;
                Debug.WriteLine(msg);
            }
            // Continue recursion.
            EnumerateConversation(myItem, conversation);
          }
       }
    }

    for (int i = 0; i <= jArray.count; i++)
    {
        Outlook.Application oOutlook = new Outlook.Application();
        Outlook.NameSpace oNs = oOutlook.GetNamespace("MAPI");
        Outlook.MAPIFolder inBox = oNs.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);
        Outlook.Items inBoxItems = inBox.Items;
        Outlook.MailItem newEmail = null;
    
        inBoxItems = inBoxItems.Restrict("[Unread] = true");
    
        foreach (object collectionItem in inBoxItems)
        {
            newEmail = collectionItem as Outlook.MailItem;
            //MessageBox.Show(newEmail.Subject.Remove(0, 3)); 
            if (subject == newEmail.Subject)
            {
                MessageBox.Show(newEmail.Subject);
                if ((from == newEmail.SenderEmailAddress & to == newEmail.To) & subject == newEmail.Subject)
                {
                    // save attachments
                }
                else if ((from == newEmail.SenderEmailAddress & to == newEmail.To) | subject == newEmail.Subject)
                {
                    // save attachments
                }
                else if ((from == newEmail.SenderEmailAddress | to == newEmail.To) & subject == newEmail.Subject)
                {
                    // save attachments
                }
                else if ((from == newEmail.SenderEmailAddress | to == newEmail.To) | subject == newEmail.Subject)
                {
                    // save attachments
                }
            }
            else if (subject == newEmail.Subject.Remove(0, 3))
            {
                MessageBox.Show(newEmail.Subject.Remove(0, 3));
                if ((from == newEmail.SenderEmailAddress & to == newEmail.To) & subject == newEmail.Subject.Remove(0, 3))
                {
                    // save attachments
                }
                else if ((from == newEmail.SenderEmailAddress & to == newEmail.To) | subject == newEmail.Subject.Remove(0, 3))
                {
                    // save attachments
                }
                else if ((from == newEmail.SenderEmailAddress | to == newEmail.To) & subject == newEmail.Subject.Remove(0, 3))
                {
                    // save attachments
                }
                else if ((to == newEmail.SenderEmailAddress | to == newEmail.To) | subject == newEmail.Subject.Remove(0, 3))
                {
                    // save attachments
                }
            }
        }
        reader.Close();
        dataStream.Close();
        response.Close();
    }

    // Event handler to process remote target's presence notifications
    void RemotePresence_PresenceNotificationReceived(object sender, RemotePresenceNotificationEventArgs e)
    {
        // Notifications contain all the notifications for one user.
        foreach (RemotePresentityNotificationData notification in e.Notifications)
        {
            // Each user will send a list of updated categories. We will choose the ones we're interested in and process them.
            foreach (PresenceCategoryWithMetaData category in notification.Categories)
            {
                if (category.Name.Equals("contactCard"))
                {
                    //get the xml data
                    string rawXml = category.CreateInnerDataXml();
                    if (rawXml == null || rawXml.Trim().Length == 0)
                    {
                        break;
                    }
    
                    StringReader reader = new StringReader(rawXml);
                    XmlDocument metadataDocument = new XmlDocument();
                    metadataDocument.Load(reader);
                    // Traverse the xml to get the phone numbers
                }
            }
        }
    }

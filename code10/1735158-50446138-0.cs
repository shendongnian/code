        public static void ReadOutlookResponse(string outlookAppointmentName)
        {
            Outlook.Items folderItems = null;
            string searchCriteria = "[Subject]='" + outlookAppointmentName + "'";
            // 1 - Returns Only 1
            MeetingItem item = null;
            Application myoutlook = new Application();
            item = myoutlook.Session.GetDefaultFolder(OlDefaultFolders.olFolderInbox).Items
                .Find("[Subject]='" + outlookAppointmentName + "'");
            string body = item.Body;
            // 2 - Loop and Return All
            folderItems = myoutlook.Session.GetDefaultFolder(OlDefaultFolders.olFolderInbox).Items;
            object resultItem = folderItems.Find(searchCriteria);
            while (resultItem != null)
            {
                if (resultItem is Outlook.MeetingItem)
                {
                    item = resultItem as Outlook.MeetingItem;
                    body = item.Body;
                }
                Marshal.ReleaseComObject(resultItem);
                resultItem = folderItems.FindNext();
            }
        }

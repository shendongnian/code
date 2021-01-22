    MAPI mapi = new MAPI();
    IMAPIMsgStore[] stores = mapi.MessageStores;
    
            for (int i = 0; i < stores.Length; i++)
            {
                if (stores[i].DisplayName == @"SMS")
                {
                    IMAPIFolder smsSentFolder = stores[i].SentMailFolder.OpenFolder();
                    smsSentFolder.SortMessagesByDeliveryTime(TableSortOrder.TABLE_SORT_DESCEND);
                    IMAPIMessage[] messages = smsSentFolder.GetNextMessages(999);
                    for (int n = 0; n < messages.Length; n++)
                    {
                        if (messages[n].LocalDeliveryTime.Month == monat && messages[n].LocalDeliveryTime.Year == jahr)
                        {
                            smsDiesenMonat++;
                        }
                    }
                }

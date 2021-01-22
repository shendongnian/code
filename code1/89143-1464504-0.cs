                NotesView nInboxDocs = NDb.GetView("$Inbox");
                NDoc=nInboxDocs.GetFirstDocument();
                while (NDoc != null)
                {
                    if (NDoc.HasEmbedded && NDoc.HasItem("$File"))
                    {
                        // To save only first attachment //
                        //pAttachment = ((object[])NDoc.GetItemValue("$File"))[0].ToString();
                        //pAttachment = CurItem.ToString();
                        //NDoc.GetAttachment(pAttachment).ExtractFile(@"C:\Documents and Settings\Administrator\Desktop\" + pAttachment);
                        // To save all attachment //
                        object[] AllDocItems = (object[])NDoc.Items;
                        foreach (object CurItem in AllDocItems)
                        {
                            NotesItem nItem = (NotesItem)CurItem;
                            if (IT_TYPE.ATTACHMENT == nItem.type)
                            {
                                pAttachment = ((object[])nItem.Values)[0].ToString();
                                NDoc.GetAttachment(pAttachment).ExtractFile(@"C:\Documents and Settings\Administrator\Desktop\" + pAttachment);
                            }
                        }
                    }
                    NDoc = nInboxDocs.GetNextDocument(NDoc);
                }

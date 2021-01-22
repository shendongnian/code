    foreach (object attachment in (object[])nItem.Values)
            {
                NotesEmbeddedObject attachfile = (NotesEmbeddedObject)docInbox.GetAttachment(attachment.ToString());
                if (attachfile != null)
                {
                    attachfile.ExtractFile("C:\\test\\" + attachment.ToString());
                }
            }

            NotesDocument doc = viewItems.GetNthEntry(rowCount).Document;
            if (doc.HasEmbedded)
            {
               object[] items = (object[])doc.Items;
               foreach (NotesItem item in items)
               {
                  if(item.Name.Equals("$FILE"))
                  {
                     object[] values = (object[])item.Values;
                     doc.GetAttachment(values[0].ToString()).ExtractFile(fileSavePath + values[0].ToString());
                  }
               }

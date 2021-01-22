     StringBuilder sb = new StringBuilder()
    
     foreach (CdcEntry element in serviceResponse.Cdc)
     {
         sb.AppendLine(element.Name);
         foreach (CdcEntryItem item in element.Items)
         {
            sb.AppendLine(" ({0},{1}) ", item.Key, item.Value);
          }
     }

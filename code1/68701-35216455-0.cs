     public void CopyItemsFromOneListToAnotherList(SPListItemCollection itemCollection)
     {  
     using (SPSite site = new SPSite(siteUrl))
     {
      using (SPWeb web = site.OpenWeb())
      {
         //Get destination list/library
         //destListName - Destination list/library name
       SPList destList = web.Lists.TryGetList(destListName);
    
       foreach (SPListItem sourceItem in itemCollection)
       {
        //Add new Item to list
        SPListItem destItem = destList.Items.Add();
        
        foreach (SPField field in sourceItem.Fields)
        {
         if (!field.ReadOnlyField && !field.Hidden && field.InternalName != "Attachments")
         {
          if (destItem.Fields.ContainsField(field.InternalName))
          {
           //Copy item to  destination library
             destItem[field.InternalName] = sourceItem[field.InternalName];
          }
         }
        }
        //Update item in destination  library or list
        destItem.Update();
        Console.WriteLine("Copied " + sourceItem["ID"] + "to destination list/library");
       }
      }
     }
      
     }

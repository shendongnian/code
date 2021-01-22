    ItemType items = default(ItemType);
    switch(sortColumn)
    {
         case "Title":
         {
               items = ctxModel.Items
                        .Where(i => i.ItemID == vId)
                        .OrderBy( i => i.Title);
         }
         break;
     }

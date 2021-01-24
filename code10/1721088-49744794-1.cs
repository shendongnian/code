    foreach(var item in MyItemsToSave)
    {
    
        try{
            context.MyItems.Add(item);
            context.SaveChanges();
        }
        catch(Exception e)
        {
           while (item.<FKColl>.Count > 0)
           {
               context.Detach(item.<FKColl>.First());
           }
          context.Detach(item);
        }
    }

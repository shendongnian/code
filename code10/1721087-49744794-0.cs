    foreach(var item in MyItemsToSave)
    {
    
        try{
            context.MyItems.Add(item);
            context.SaveChanges();
        }
        catch(Exception e)
        {
          continue;
        }
    }

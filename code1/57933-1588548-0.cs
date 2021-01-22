    private static void ApplyItemUpdates(SalesOrderDetail updatedItem){
    // Define an ObjectStateEntry and EntityKey for the current object.
    EntityKey key;
    object originalItem;
    using (AdventureWorksEntities advWorksContext =
        new AdventureWorksEntities())
    {
        try
        {
            // Create the detached object's entity key.
            key = advWorksContext.CreateEntityKey("SalesOrderDetail", updatedItem);
            
            // Get the original item based on the entity key from the context
            // or from the database.
            if (advWorksContext.TryGetObjectByKey(key, out originalItem))
            {
                // Call the ApplyPropertyChanges method to apply changes
                // from the updated item to the original version.
                advWorksContext.ApplyPropertyChanges(
                    key.EntitySetName, updatedItem);
            }
            advWorksContext.SaveChanges();
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }

        try
        {
            // Try to save changes, which may cause a conflict.
            int num = context.SaveChanges();
            Console.WriteLine("No conflicts. " +
                num.ToString() + " updates saved.");
        }
        catch (OptimisticConcurrencyException)
        {
            // Resolve the concurrency conflict by refreshing the 
            // object context before re-saving changes. 
            context.Refresh(RefreshMode.ClientWins, orders);
            // Save changes.
            context.SaveChanges();
            Console.WriteLine("OptimisticConcurrencyException "
            + "handled and changes saved");
        }

    public T getSingleItem(Func<T,bool> idSelector ) where T : ??? // forgot what type it needs to be off the top of my head
    { 
        try 
        { 
            using (DataContext context = new DataContext(ConnectionStringManager.getLiveConnStr())) 
            { 
                context.DeferredLoadingEnabled = false; 
                return context.GetTable<T>().Single( item => idSelector( item );
            } 
        }
        catch (Exception e) 
        { 
            Logger.Log("Can't get requested item.", e); 
            throw; 
        } 
    } 

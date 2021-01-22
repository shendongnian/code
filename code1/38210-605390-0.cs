    public void NotifySubscribers(DataRecord sr)
    {
        toBeRemoved.Clear();
        ...your unchanged code skipped...
       foreach ( Guid clientId in toBeRemoved )
       {
            try
            {
                subscribers.Remove(clientId);
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Unsubscribe Error " + 
                    e.Message);
            }
       }
    }
    ...your unchanged code skipped...
    public void UnsubscribeEvent(Guid clientId)
    {
        toBeRemoved.Add( clientId );
    }

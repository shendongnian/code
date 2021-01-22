    public class SynchronizationInterface
    {
        public SyncContext GetChanges(SyncGroupMetadata groupMetadata, SyncSession syncSession)
        {
            SyncContext syncContext;
            syncContext = syncServiceClient.GetChanges(groupMetadata,syncSession);
            //Inspect and or modify the syncContext that's received.
            return syncContext;
         }
         //Implement ApplyChanges, GetServerInfo, GetSchema in the same manner.
    }

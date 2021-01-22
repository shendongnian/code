        public class DbServerSyncProviderProxy : ServerSyncProvider
        {
            SyncServiceProxy.SyncServiceClient serviceProxy = new SyncServiceProxy.SyncServiceClient();
            public override SyncContext ApplyChanges(SyncGroupMetadata groupMetadata, DataSet dataSet, SyncSession syncSession)
            {
                return serviceProxy.ApplyChanges(groupMetadata, dataSet, syncSession);
            }
        }

        [ServiceContract]
        public interface ISyncService
        {
            [OperationContract]
            SyncContext ApplyChanges(SyncGroupMetadata groupMetadata, DataSet dataSet, SyncSession syncSession);
            [OperationContract]
            SyncContext GetChanges(SyncGroupMetadata groupMetadata, SyncSession syncSession);
            [OperationContract]
            SyncSchema GetSchema(Collection<string> tableNames, SyncSession syncSession);
            [OperationContract]
            SyncServerInfo GetServerInfo(SyncSession syncSession);
        }

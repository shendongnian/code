     public static void Sync()
        {
            SqlConnection serverConn = new SqlConnection(sServerConnection);
            SqlConnection clientConn = new SqlConnection(sClientConnection);
            SyncOrchestrator syncOrchestrator = new SyncOrchestrator();
            syncOrchestrator.LocalProvider = new SqlSyncProvider(sScope, clientConn);
            syncOrchestrator.RemoteProvider = new SqlSyncProvider(sScope, serverConn);
            syncOrchestrator.Direction = SyncDirectionOrder.Upload;
            ((SqlSyncProvider)syncOrchestrator.LocalProvider).ApplyChangeFailed += new EventHandler<DbApplyChangeFailedEventArgs>(Program_ApplyChangeFailed);
            SyncOperationStatistics syncStats = syncOrchestrator.Synchronize();
            Console.WriteLine("Start Time: " + syncStats.SyncStartTime);
            Console.WriteLine("Total Changes Uploaded: " + syncStats.UploadChangesTotal);
            //Console.WriteLine("Total Changes Downloaded: " + syncStats.DownloadChangesTotal);
            Console.WriteLine("Complete Time: " + syncStats.SyncEndTime);
            Console.WriteLine(String.Empty);
            Console.ReadLine();
        }

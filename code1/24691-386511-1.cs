    public class SampleSyncAgent : Microsoft.Synchronization.SyncAgent
     {
    
         public SampleSyncAgent()
         {
             
             SqlCeClientSyncProvider clientSyncProvider = new SqlCeClientSyncProvider(Properties.Settings.Default.ClientConnString, true);
             this.LocalProvider = clientSyncProvider;
                  clientSyncProvider.ChangesApplied += new EventHandler<ChangesAppliedEventArgs>(clientSyncProvider_ChangesApplied);    
    
             this.RemoteProvider = new SampleServerSyncProvider();    
    
             SyncTable customerSyncTable = new SyncTable("Customer");
             customerSyncTable.CreationOption = TableCreationOption.DropExistingOrCreateNewTable;
             customerSyncTable.SyncDirection = SyncDirection.DownloadOnly;**
    
             this.Configuration.SyncTables.Add(customerSyncTable);
             this.Configuration.SyncParameters.Add(new SyncParameter("@CustomerName", "Sharp Bikes"));
         }
    
    } 

    //You single Cache class
    public sealed class ClientCache
    {
         #region Singleton implementation
         private static  ClientCache _clientCache = new ClientCache();
               
    
         private ClientCache()
         {
    
         }
    
         public static ClientCache Instance => _clientCache;    
         #endregion
        
         //Timer for syncing the data from Server
         private Timer _timer;
         //This data is the cached one
         public string data = string.Empty;
    
         internal void StartProcess()
         {
                //Initializing the timer
                _timer = new Timer(TimeSpan.FromMinutes(1).TotalMilliseconds); //This timespan is configurable
                //Assigning it an elapsed time event
                _timer.Elapsed += async (e, args) => await SyncServerData(e, args);
                //Starting the timer 
                _timer.Start();
    
         } 
    
         //In this method you will request your server and fetch the latest copy of the data
         //In case of failure you can maintain the history of the last disconnected server
         private async Task ProcessingMethod(object sender, ElapsedEventArgs e)
         {
             //First we will stop the timer so that any other hit don't come in the mean while
             timer.Stop();
    
             //Call your api here 
             //Once the hit is completed or failed 
             //On Success you will be updating the Data object
             //data = result from your api call  
    
             //Finally start the time again as
             timer.Start();
         } 
    
    }

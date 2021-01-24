    public Task<AccountState> SomeCommandSentToServerAsync(string key)
    {
         var taskCompletionSource = new TaskCompletionSource<AccountState>();
    
         //  Find a way to keep the task in some state somewhere
         //  so that you can get it the polling thread.
    
         //  Do the legacy WinSock Send() command.
    
         return taskCompletionSource.Task;
    }
    
    private void PollingThread()
    {
         // 
         while(polling)
         {
             //  Check for some response.
    
             if(this_is_THE_response)
             {
                 // Get the response and built the account state somehow...
    
                 AccountState accountState = ...
    
                 // Grab the TaskCompletionSource somewhere.
    
                 // This is the magic line:
                 taskCompletionSource.SetResult(accountState);
    
                 // You can also do the following if something goes wrong:
                 // taskCompletionSource.SetException(new Exception());
             }
         }
    }

        public Task<AccountState> SomeCommandSentToServerAsync(string key)
        {
            var taskCompletionSource = new TaskCompletionSource<AccountState>();
    
            //  Find a way to keep the task in some state somewhere
            //  so that you can get it the polling thread.
    
            //  Do the legacy WinSock Send() command.
    
            return taskCompletionSource.Task;
        }
        
        // This would be, I guess, your polling thread.
        // Again, I am sure it is not 100% accurate but 
        // it will hopefully give you an idea of where the key pieces must be.
        private void PollingThread()
        {
             while(must_still_poll)
             {
                 //  Waits for some data to be available.
                 //  Grabs the data.
        
                 if(this_is_THE_response)
                 {
                     // Get the response and built the account state somehow...
        
                     AccountState accountState = ...
        
                     // Key piece #1
                     // Grab the TaskCompletionSource instance somewhere.
        
                     // Key piece #2
                     // This is the magic line:
                     taskCompletionSource.SetResult(accountState);
        
                     // You can also do the following if something goes wrong:
                     // taskCompletionSource.SetException(new Exception());
                 }
             }
        }

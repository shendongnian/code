    public void ContinueWithOperation()  
    {  
       Task<string> t = Task.Run(() => LongRunningOperation("Continuewith", 500));  
       t.ContinueWith((t1) =>  
       {  
          // check t1 for errors here
          Console.WriteLine(t1.Result);  
       });  
    }  
    //Fake async! very smelly
    public async Task AsyncOperation()  
    {
       try
       {
          string t = await Task.Run(() => LongRunningOperation("AsyncOperation", 1000));  
          Console.WriteLine(t);  
       }
       catch (Exception e)
       {
           // check for errors here
       }
    } 
    // Ideally 
    public async Task OperationAsync()  
    {
       try
       {
          string t = await LongRunningOperationAsync("AsyncOperation", 1000);  
          Console.WriteLine(t);  
       }
       catch (Exception e)
       {
           // check for errors here
       }
    } 

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

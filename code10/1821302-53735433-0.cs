    public void ContinueWithOperation()  
    {  
       Task<string> t = Task.Run(() => LongRunningOperation("Continuewith", 500));  
       t.ContinueWith((t1) =>  
       {  
          // check t1 for errors here
          Console.WriteLine(t1.Result);  
       });  
    }  

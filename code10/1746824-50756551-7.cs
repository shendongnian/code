     public async Task Post()
     {
         try
         {
             // ... other serialization code here ...
             await HttpPostAsync();
         }
         catch (Exception ex)
         {
             // Do you have a logger of last resort?
             Trace.WriteLine(ex.Message);
         }
     }

    public void ClientAppMessageLoop()
    {
        bool running = true;
        while (running)
        {
            object inputData = GetInputFromUser();
            try
            {
                ServiceLevelMethod(inputData);
            }
            catch (Exception ex)
            {
                // Error occurred, notify user and let them recover
            }
        }
    }
    // ...
    public void ServiceLevelMethod(object someinput)
    {
        using (SomeComponentThatsDisposable blah = new SomeComponentThatsDisposable())
        {
            blah.PerformSomeActionThatMayFail(someinput);
        } // Dispose() method on SomeComponentThatsDisposable is called here, critical resource freed regardless of exception
    }
    
    // ...
    
    public class SomeComponentThatsDisposable: IDosposable
    {
        public void PErformSomeActionThatMayFail(object someinput)
        {
            // Get some critical resource here...
    
            // OOPS: We forgot to check if someinput is null below, NullReferenceException!
            int hash = someinput.GetHashCode();
            Debug.WriteLine(hash);
        }
    
        public void Dispose()
        {
            GC.SuppressFinalize(this);
    
            // Clean up critical resource if its not null here!
        }
    }

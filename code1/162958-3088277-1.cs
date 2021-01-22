    try
    {
    	Mutex foundMutex = Mutex.OpenExisting("MyTestingMutex");
    
    	// Found Mutex
    	foundMutex.ReleaseMutex();
    }
    catch (System.Threading.WaitHandleCannotBeOpenedException)
    {
    	//   System.Threading.WaitHandleCannotBeOpenedException:
    	//     The named mutex does not exist.
    }

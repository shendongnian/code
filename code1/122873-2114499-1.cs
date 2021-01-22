    System.Threading.WaitHandle[] waits = new System.Threading.WaitHandle[255];
    //initialise the list of these and create the objects to ping.
    foreach (var obj in mylistofobjectvalues)
    {
        System.Threading.Threadpool.QueueUserWorkItem(method, obj);
    }
    System.Threading.WaitHandle.WaitAll(waits);

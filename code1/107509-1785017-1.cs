    IAsyncResult ar = data.BeginInvoke(Callback, null);
    //Automatically gets called after climbing is complete because we specified this
    //in the call to BeginInvoke
    public static void Callback(IAsyncResult result) {
        Console.WriteLine("..Climbing is completed...");
    }

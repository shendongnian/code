    bool myBool;
    bool retrievingMyBool;
    RetrieveABoolean(5);    
    
    public bool RetrieveABoolean(int id)
    {
        client.CallAnAsyncMethod(id);  // value is returned in a completed event handler.  Need to somehow get that value into aBool.
        retrievingMyBool = true;
        while (retrievingMyBool)
        {
            Thread.Sleep(100);
        }
    }
    
    private void completedEventHandler([[parameters go here]])
    {
        // code to handle parameters
        myBool = // whatever
        retrievingMyBool = false    
    }

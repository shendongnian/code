    void DoStuff()
    {
        string message = string.Empty;
        try {
            BranchOnContext();
        } catch (MyExpectedException me) { // only catch exceptions I'm prepared to handle
             message = me.Message;
        }  
        DoSomethingElse(message);  // Always the next thing to be executed
    }

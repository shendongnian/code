    string userName = "Test";
    string password = "Test";
    object[] arguments = new object[] { userName, password };
    
    ContextRegister.GetContext().GetObject("WinFormApplicationWorkflow", arguments);

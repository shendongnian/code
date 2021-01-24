    public async Task SomeMethodOnMyController ()
    {
        await SomethingAsync();
    }
    
    async Task SomethingAsync()
    {
       await _emailSystem.SendEmailsAsync();
    }
        

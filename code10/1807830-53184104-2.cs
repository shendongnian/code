    public async Task SomeMethodOnMyController ()
    {
        await SomethingAsync();
    }
    
    async Task SomethingAsync()
    {
       // do something thrilling here
       await _emailSystem.SendEmailsAsync();
       // do something thrilling here
    }
        

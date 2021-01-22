    using SMTPConnectionTest;
    
    if (SMTPConnection.Ok("myhost", 25))
    {
       // Ready to go
    }
    
    if (SMTPConnectionTester.Ok()) // Reads settings from <smtp> in .config
    {
        // Ready to go
    }

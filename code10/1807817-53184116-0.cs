    // This method has to be async
    public Response SomeHTTPAction()
    {
         // Some logic...
         // ...
         // Send an Email but don't care if it successfully sent.
         Task.Factory.StartNew(() =>  _emailService.SendEmailAsync());
         return MyRespond();
    }

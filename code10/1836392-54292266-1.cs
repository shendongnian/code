    private void NotifyCallback(object model)
    {
       // some notification logic
       // that uses a field [_reqContext]
       string email = _reqContext.GetEmailFromClaims();
       // Do some stuff with email but do not access any field
       Console.WriteLine(email);   
       Console.WriteLine("Done");
       GC.KeepAlive(this); // The GC won't collect the object before this line
    }

    connection.PropertyChanged += (s,e) =>
    {
       if (e.PropertyName == nameof(YourClass.IsDisconnected))
       { 
           //isDisconnected changed, perform your logic
       }
    }

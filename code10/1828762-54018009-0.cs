    using System.Diagnostics;
    .
    .
    public Connection connection 
    { 
        get 
        { 
            Console.WriteLine(new StackTrace().GetFrame(1).GetMethod().Name);
            return _connection;
        } 
    }

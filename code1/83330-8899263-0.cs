    Connection c = new ...; 
    Transaction t = new ...;
    
    using (new DisposableCollection(c, t))
    {
       ...
    }

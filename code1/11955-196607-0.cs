    using (MyDataContext ctx = new MyDataContext())
    {
        StringWriter sw = new StringWriter();
        ctx.Log = sw;
    
        // execute some LINQ to SQL operations...
    
        string sql = sw.ToString();
        // put a breakpoint here, log it to a file, etc...
    }   

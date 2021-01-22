    public DataTable SearchAll(string term, List<int> indices) 
    {
        var asyncs = new List<IAsyncResult>();
        foreach(int index in indices) 
        {
             SearchAsync sa = new SearchAsync(NewMethodSearchWithTermAndIndexParemeter);
             asyncs.Add(sa.BeginInvoke(term, index, null, null));
        }
        var tables = new List<DataTable>();
        foreach(IAsyncResult iar in asyncs) 
        {
             try 
             {
                  tables.Add(sa.EndInvoke(iar));
             }
             catch 
             {
                 ...appropriately handle
             } 
        }
        .... merge tables
    }

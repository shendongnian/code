    static async Task MainAsync(string[] args)
    {
        DataSet ds = new DataSet();
        /*logic for getting dataset values.table0 contains posting file details
        and Table1 contains details of files which need response*/
    
        List<Task> tasks = new List<Task>(2);
        //"starting Posting files to API";
        tasks.Add(PostDatas(ds));
        //"Ending Posting files to API";
    
        //"Getting Response from the API";
        tasks.Add(GetResponseXML(ds));
        //"Ending Getting Response from the API";
    
        await Task.WhenAll(tasks);
    }

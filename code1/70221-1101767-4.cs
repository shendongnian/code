    private int NextID = 0;
    private struct QueryArguments
    {
        public QueryArguments()
        {
        }
        public QueryArguments(int QueryID, string Query)
            : this()
        {
            this.QueryID = QueryID;
            this.Query = Query;
        }
        public int QueryID { get; set; }
        public string Query { get; set; }
        public string Result { get; set; }
    }
    private int StartQuery(string query)
    {
        QueryArguments args = new QueryArguments(NextID++, query);
        BackgroundWorker backgroundWorker1 = new BackgroundWorker();
        backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
        backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
        backgroundWorker1.RunWorkerAsync(args);
        return args.QueryID;
    }
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {   
        QueryArguments args = (QueryArguments)e.Argument;
        args.Result = SQLGet(args.Query);
        e.Result = args;
    }
    private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        QueryArguments args = (QueryArguments)e.Result;
        //args.Result contains the result
        //do something
    }
    

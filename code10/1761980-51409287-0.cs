        readonly string _baseUrl = "https://api.iextrading.com/1.0/";
        const int MAXPARA = 2;
        TransformBlock<string, CompanyInfo> GetCompanyInfo;
        TransformBlock<string, List<Dividend>> GetDividendReports;
        TransformBlock<string, KeyStats> GetKeyStatInfo;
        TransformBlock<string, List<Interval>> GetIntervalReports;
        TransformBlock<List<Interval>, List<decimal>> GetChangesOverInterval;
        BroadcastBlock<string> broadcastSymbol;
        TransformBlock<Tuple<List<decimal>, List<Dividend>, KeyStats>, string> GenerateXmlString;
        ActionBlock<string> GenerateCompleteReport;
        CancellationTokenSource cancellationTokenSource;
        public void StartPipeline()
        {
            //Add cancelation to the pipeline
            cancellationTokenSource = new CancellationTokenSource();
            ExecutionDataflowBlockOptions executionDataflowBlockOptions = new ExecutionDataflowBlockOptions
            {
                CancellationToken = cancellationTokenSource.Token,
                MaxDegreeOfParallelism = MAXPARA
            };
            broadcastSymbol = new BroadcastBlock<string>(symbol => symbol);
            var joinblock = new JoinBlock<List<decimal>, List<Dividend>, KeyStats>(new GroupingDataflowBlockOptions { Greedy = false });
            GetCompanyInfo = new TransformBlock<string, CompanyInfo>(symbol =>
            {
                return RetrieveCompanyInfo(symbol);
            }, executionDataflowBlockOptions);
            GetDividendReports = new TransformBlock<string, List<Dividend>>(symbol =>
            {
                return RetrieveDividendInfo(symbol);
            }, executionDataflowBlockOptions);
            GetKeyStatInfo = new TransformBlock<string, KeyStats>(symbol =>
            {
                return RetrieveKeyStats(symbol);
            }, executionDataflowBlockOptions);
            GetIntervalReports = new TransformBlock<string, List<Interval>>(symbol =>
            {
                return RetrieveIntervals(symbol, 30);
            }, executionDataflowBlockOptions);
            GetChangesOverInterval = new TransformBlock<List<Interval>, List<decimal>>(intervals =>
            {
                return ConstructIntervalReport(intervals);
            }, executionDataflowBlockOptions);
            GenerateXmlString = new TransformBlock<Tuple<List<decimal>, List<Dividend>, KeyStats>, string>(tup =>
            {
                var ReportObj = new Report
                {
                    changeIntervals = tup.Item1,
                    dividends = tup.Item2,
                    keyStats = tup.Item3
                };
                XmlSerializer ser = new XmlSerializer(typeof(Report));
                var stringWriter = new StringWriter();
                ser.Serialize(stringWriter, ReportObj);
                return stringWriter.ToString();
            }, executionDataflowBlockOptions);
            GenerateCompleteReport = new ActionBlock<string>(xml =>
            {
                var str = Path.GetRandomFileName().Replace(".", "") + ".xml";
                File.WriteAllText(str, xml);
                Console.WriteLine("Finished File");
            }, executionDataflowBlockOptions);
            var options = new DataflowLinkOptions { PropagateCompletion = true };
            var buffer = new BufferBlock<string>();
            buffer.LinkTo(broadcastSymbol, options);
            //Need to make sure all data is recieved for each linked block
            //Broadcast block only sends completion notice to one of the linked blocks
            broadcastSymbol.Completion.ContinueWith(tsk =>
            {
                if(!tsk.IsFaulted)
                {
                    GetIntervalReports.Complete();
                    GetDividendReports.Complete();
                    GetKeyStatInfo.Complete();
                }
                else
                {
                    ((IDataflowBlock)GetIntervalReports).Fault(tsk.Exception);
                    ((IDataflowBlock)GetDividendReports).Fault(tsk.Exception);
                    ((IDataflowBlock)GetKeyStatInfo).Fault(tsk.Exception);
                }
            });
            //Broadcasts the symbol
            broadcastSymbol.LinkTo(GetIntervalReports, options);
            broadcastSymbol.LinkTo(GetDividendReports, options);
            broadcastSymbol.LinkTo(GetKeyStatInfo, options);
            //Second teir parallel 
            GetIntervalReports.LinkTo(GetChangesOverInterval, options);
            //Joins the parallel blocks back together
            GetDividendReports.LinkTo(joinblock.Target2, options);
            GetKeyStatInfo.LinkTo(joinblock.Target3, options);
            GetChangesOverInterval.LinkTo(joinblock.Target1, options);
            joinblock.LinkTo(GenerateXmlString, options);
            GenerateXmlString.LinkTo(GenerateCompleteReport, options);
            buffer.Post("F");
            buffer.Post("AGFS");
            buffer.Post("BAC");
            buffer.Post("FCF");
            buffer.Complete();
            GenerateCompleteReport.Completion.Wait(cancellationTokenSource.Token);
        }

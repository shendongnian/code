        static void Main(string[] args)
        {
            var kcsb = new KustoConnectionStringBuilder("https://help.kusto.windows.net").WithAadUserPromptAuthentication();
            var databaseName = "Samples";
            using (var queryProvider = KustoClientFactory.CreateCslQueryProvider(kcsb))
            {
                var clientRequestProperties = new ClientRequestProperties() { ClientRequestId = "Sample;" + Guid.NewGuid() };
                var query = "StormEvents | summarize count(), max(EndTime) by State";
                var result = queryProvider.ExecuteQuery<MyType>( // focus on this part
                    databaseName,
                    query,
                    clientRequestProperties)
                    .ToList();
                foreach (var row in result)
                {
                    Console.WriteLine($"State = {row.State}, Count = {row.Count}, MaxEndTime = {row.MaxEndTime}");
                }
            }
        }
        class MyType
        {
            public string State;
            public long Count;
            public DateTime MaxEndTime;
        }

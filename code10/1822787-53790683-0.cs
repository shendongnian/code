    class DataReader
    {
        public CancellationTokenSource CTS { get; } = new CancellationTokenSource();
        internal void GetData()
        {
            // Use the desired data type instead of string
            var values = new BlockingCollection<string>();
            var readTask = Task.Factory.StartNew(() =>
            {
                try
                {
                    // here your code
                    for (...)
                    {
                        if (CTS.Token.IsCancellationRequested)
                            break;
                        foreach (var row in rawdata)
                        {
                            DataRowReadArgs args = new DataRowReadArgs(row.Index);
                            //...
                            values.Add(args); // put value to blocking collection
                        }
                    }
                }
                catch (Exception e) { /* process possible exception */}
                finally { values.CompleteAdding(); }
            }, TaskCreationOptions.LongRunning);
            var processTask = Task.Factory.StartNew(() =>
            {
                foreach (var value in values.GetConsumingEnumerable())
                {
                    if (CTS.Token.IsCancellationRequested)
                        break;
                    // process value
                }
            }, TaskCreationOptions.LongRunning);
            Task.WaitAll(readTask, processTask);            
        }
    }

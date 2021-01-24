        /// <summary>
        /// I didn't test this, I am assuming you can work out the details
        /// (I prefer this way)
        /// </summary>
        /// <returns></returns>
        private void Run_Click(object sender, EventArgs e)
        {
            var response = new ConcurrentBag<PSObject>();
            var exceptions = new ConcurrentQueue<Exception>();
            string[] servers = { "server1", "server2", "server3", "server4", "server5" };
            try
            {
                Parallel.ForEach(servers, server =>
                {
                    response.Add(runPowerShellScript(server));
                });
            }
            catch (AggregateException ae)
            {
                foreach (var e in ae.InnerExceptions)
                {
                    exceptions.Enqueue(e);
                }
            }
            if (exceptions.ToList().Any())
            {
                //there are exceptions, do something with them
                //do something?
            }
            try
            {
                // quote:  // process data here
            }
            catch (Exception e)
            {
                // do something with it
            }
        }

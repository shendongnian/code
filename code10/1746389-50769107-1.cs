    private async void button1_Click(object sender, EventArgs e)
    {
        // Make a list of host names to ping
        List<string> hostnames = new List<string>();
    
        // Use local hostnames a .. z. 
        // and domain names a.com .. z.com
        for(char c = 'a'; c <= 'z'; c++)
        {
            hostnames.Add(c.ToString());
            hostnames.Add("www." + c + ".com");
        }
    
        // Use some well known hostnames
        hostnames.Add("www.google.com");
        hostnames.Add("www.microsoft.com");
        hostnames.Add("www.apple.com");
                
        // Ping the hostnames and get the results as a dictionary
        IReadOnlyDictionary<string, bool> results = await Task.Run(() => PingHosts(hostnames));
    
        // Output the content of the results, note that the order 
        // is not the same as in the original list of
        // hostnames because of parallel processing
        foreach(var result in results)
        {
            if(result.Value)
            {
                textBox1.AppendText("Ping to " + result.Key + ": OK" + Environment.NewLine);
            }
            else
            {
                textBox1.AppendText("Ping to " + result.Key + ": ERROR" + Environment.NewLine);
            }
        }
    }
    
    // This function will ping a single host and return true or false
    // based on whether it can be pinged
    private bool PingSingleHost(string hostname)
    {
        try
        {
            Ping ping = new Ping();
            var reply = ping.Send(hostname, 1000);
            bool wasSuccessful = reply.Status == IPStatus.Success;
            return wasSuccessful;
        }
        catch(Exception)
        {
            return false;
        }
    }
    
    // Ping the given list of hostnames and return their status
    // (can they be pinged) as a dictionary where the Key is the hostname
    // and the value is a boolean with the ping result
    private IReadOnlyDictionary<string, bool> PingHosts(IEnumerable<string> hostnames)
    {
        // Use 30 parallel worker threads
        // This number can be quite high because the
        // workers will spend most time waiting 
        // for an answer
        int numberOfWorkers = 30;
    
        // Place the hosts into a queue
        ConcurrentQueue<string> jobsQueue = new ConcurrentQueue<string>(hostnames);
    
        // Use a concurrent dictionary to store the results
        // The concurrent dictionary will automatically handle
        // multiple threads accessing the dictionary at the same time
        ConcurrentDictionary<string, bool> results = new ConcurrentDictionary<string, bool>();
    
        // Worker function which keeps reading new hostnames from the given jobsQueue
        // and pings those hostnames and writes the result to the given results dictionary
        // until the queue is empty
        ThreadStart Worker = () =>
        {
            string hostname;
    
            // While the job queue is not empty, get a host from the queue
            while(jobsQueue.TryDequeue(out hostname))
            {
                // Ping the host and 
                bool wasSuccessful = PingSingleHost(hostname);
    
                // write the result to results dictionary
                results.TryAdd(hostname, wasSuccessful);
            }
        };
    
    
        // Start the Worker threads
        List<Thread> workers = new List<Thread>();
    
        for(int i = 0; i < numberOfWorkers; i++)
        {
            Thread thread = new Thread(Worker);
            thread.Start();
            workers.Add(thread);
        }
    
        // Wait for all workers to have finished
        foreach(var thread in workers)
        {
            thread.Join();
        }
    
        return results;
    }

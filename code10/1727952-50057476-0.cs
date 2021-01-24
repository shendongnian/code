		int workerCount = Environment.ProcessorCount * 5;
        string queueName = "web_app_queue";
        List<IBackgroundProcess> processes = GetProcessesForBackgroundServer(queueName, workerCount);
        var backgroundJobServer = new BackgroundProcessingServer(JobStorage.Current, processes, new Dictionary<string, object> { { "Queues", new string[] { queueName } }, { "WorkerCount", workerCount } });
        private List<IBackgroundProcess> GetProcessesForBackgroundServer(string queueName, int workerCount)
        {
            var processes = new List<IBackgroundProcess>();
            for (var i = 0; i < workerCount; i++)
            {
                processes.Add(new Worker(queueName)); //only fire-and-forgot jobs will be processed by this server (important processes ServerHeartbeat, ServerWatchdog are included automatically by BackgroundProcessingServer)
            };
            return processes;
        }

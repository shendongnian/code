    public QueuePollingFunction(
            IOptions<QueueOptions> queueOptions,
            CloudQueue queue)
        {
            this.isEnabled = queueOptions.Value.IsEnabled;
            this.StartPollingQueue(queue);
        }
           public override async Task<bool> ProcessMessageAsync(string message)
        {
            bool result = false;
            try
            {
                var messageContent = JsonConvert.DeserializeObject<QueueEntity>(message);
                result = true;
            }
            catch (Exception e)
            {
                Trace.TraceError(e.ToString());
            }
            return result;
        }
        private async Task StartPollingQueue(CloudQueue queue)
        {
            if (this.isEnabled)
            {
                Task pollQueue = Task.Factory.StartNew(() => Parallel.For(0, this.numberOfParallelTasks, work =>
                {
                    this.Start(queue);
                }));
            }
        }
        private async Task Start(CloudQueue queue)
        {
            while (true)
            {
                try
                {
                    CloudQueueMessage retrievedMessage = await queue.GetMessageAsync();
                    if (retrievedMessage != null)
                    {
                        // Fail Logic
                        if (retrievedMessage.DequeueCount > this.maxRetryLimit)
                        {
                            await queue.DeleteMessageAsync(retrievedMessage);
                        }
                        bool isPass = await this.ProcessMessageAsync(newChannelSettings);
                        if (isPass)
                        {
                            await queue.DeleteMessageAsync(retrievedMessage);
                        }
                    }
                    else
                    {
                        // If queue is empty, then the Task can sleep for sleepTime duration
                        await Task.Delay(this.sleepTime);
                    }
                }
                catch (Exception e)
                {
                    Trace.TraceError(e.ToString());
                }
            }
        }

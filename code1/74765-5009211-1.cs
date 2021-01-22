         public static void FlushLogs()
        {
            int queueCount;
            bool isProcessingLogs;
            while (true)
            {
                //wait for the current iteration to complete
                m_waitingThreadEvent.WaitOne();
                //check to see if we are currently processing logs
                lock (m_isProcessingLogsSync)
                {
                    isProcessingLogs = m_isProcessingLogs;
                }
                //check to see if more events were added while the logger was processing the last batch
                lock (m_loggerQueueSync)
                {
                    queueCount = m_loggerQueue.Count;
                }                
                if (queueCount == 0 && !isProcessingLogs)
                    break;
                
                //since something is in the queue, reset the signal so we will not keep looping
                Thread.Sleep(400);
            }
        }

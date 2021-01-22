    public static void FlushLogs()
            {   
                bool queueHasValues = true;
                while (queueHasValues)
                {
                    //wait for the current iteration to complete
                    m_waitingThreadEvent.WaitOne();
    
                    lock (m_loggerQueueSync)
                    {
                        queueHasValues = m_loggerQueue.Count > 0;
                    }
                }
    
                //force MEL to flush all its listeners
                foreach (MEL.LogSource logSource in MEL.Logger.Writer.TraceSources.Values)
                {                
                    foreach (TraceListener listener in logSource.Listeners)
                    {
                        listener.Flush();
                    }
                }
            }

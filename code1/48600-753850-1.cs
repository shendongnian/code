        private void CompleteAndQueuePayLoads(
               IEnumerable<UsagePayload> payLoads, string processId)
        {
            List<WaitHandle> waitHndls = new List<WaitHandle>();
            int defaultMaxwrkrThreads, defaultmaxIOThreads;
            ThreadPool.GetMaxThreads(out defaultMaxwrkrThreads, 
                                     out defaultmaxIOThreads);
            ThreadPool.SetMaxThreads(
                MDMImportConfig.MAXCONCURRENTIEEUSAGEREQUESTS, 
                defaultmaxIOThreads);
            int qryNo = 0;
            foreach (UsagePayload uPL in payLoads)
            {
                ManualResetEvent txEvnt = new ManualResetEvent(false);
                UsagePayload uPL1 = uPL;
                int qryNo1 = ++qryNo;
                ThreadPool.QueueUserWorkItem(
                    delegate
                        {
                            try
                            {
                                Thread.CurrentThread.Name = processId + 
                                                          "." + qryNo1;
                                if (!HasException && !uPL1.IsComplete)
                                     IEEDAL.GetPayloadReadings(uPL1, 
                                                      processId, qryNo1);
                                if (!HasException) 
                                    UsageCache.PersistPayload(uPL1);
                                if (!HasException) 
                                    SavePayLoadToProcessQueueFolder(
                                                 uPL1, processId, qryNo1);
                            }
                            catch (MeterUsageImportException iX)
                            {
                                log.Write(log.Level.Error,
                                   "Delegate failed "   iX.Message, iX);
                                lock (locker)
                                {
                                    HasException = true;
                                    X = iX;
                                    foreach (ManualResetEvent 
                                              txEvt in waitHndls)
                                        txEvt.Set();
                                }
                            }
                            finally { lock(locker) txEvnt.Set(); }
                        });
                waitHndls.Add(txEvnt);
            }
            util.WaitAll(waitHndls.ToArray());
            ThreadPool.SetMaxThreads(defaultMaxwrkrThreads, 
                                     defaultmaxIOThreads);
            lock (locker) if (X != null) throw X;
        }

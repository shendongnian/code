            int dueTime = int.Parse(lvTask.ctlrArray[0, 3].ToString());
            int lvCtlrIdStart = 0;
            int lvCtlrIdEnd = 0;
            object s_range = $"{lvCtlrIdStart},{lvCtlrIdEnd}";
            bool bIntvlStart = false;
            m_WorkerEvtThreads = new AutoResetEvent[NbrThrds];                                      // reset ALL events before looping into the next sets of Threadpool
            CancellationTokenSource cts = new CancellationTokenSource();                            // Create the token source
			for (int i = 0; i < NbrThrds; i++)                                                      // Iterate based on the number of tasks to run
			{
				try
				{
					int intvlStart = 1000 * i;															// delay before my callback method is invoked..
					dueTime = bIntvlStart ? int.Parse(lvTask.ctlrArray[i, 3].ToString()) : intvlStart;  // first loop is (1000 * loop_count) sec stagger run, otherwise kickoff on interval time
					m_WorkerEvtThreads[i] = new AutoResetEvent(false);                              // initial each thread event
					m_WorkerEvtThreads[i].Reset();
					Thread.Sleep(WaitHandle.WaitTimeout);                                           // sleep 258ms...
					CurrentInstance = int.Parse(lvTask.ctlrArray[i, 2].ToString()) - 1;             // get the current instance
					lvCtlrIdStart = int.Parse(lvTask.ctlrArray[i, 0].ToString());                   // start controller ID
					lvCtlrIdEnd = int.Parse(lvTask.ctlrArray[i, 1].ToString());                     // end controller ID
					s_range = $"{lvCtlrIdStart},{lvCtlrIdEnd}";                                     // combine to pass to SendQueueMessage()
					ThreadPool.QueueUserWorkItem(delegate 
												{   Thread.CurrentThread.Name = $"LV Instance {CurrentInstance}";
													lvTask.TN = $"{Thread.CurrentThread.Name}";               // name the current instance task
													m_ThreadName = $"{lvTask.TN}";
													TimerSendQueueMsgCallback(s_range, intvlStart, dueTime);    // Call the timer callback method
												}, cts.Token);													// cancellation token
				}
				catch (Exception ex)
				{
					log.WriteLineToBuf(ref logBuf, $"Exception: OnLvMessage() - {ex.Message}");
				}
			}
			cts.Cancel();																						// request cancellation...	

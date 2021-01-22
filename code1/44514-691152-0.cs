       CallerServiceDelegate callSvcDel = _caller.CallService;
       DateTime cutoffDate = DateTime.Now.AddSeconds(timeoutSeconds);
       IAsyncResult aR = callSvcDel .BeginInvoke([here put parameters], 
                                                 AsynchCallback, null);
       while (!aR.IsCompleted && DateTime.Now < cutoffDate)
           Thread.Sleep(500);
       if (aR.IsCompleted)
       {
          ReturnType returnValue = custNrgDel.EndInvoke(aR);
          // whatever else you need to do to handle success
       }
       else
       {
          custNrgDel.EndInvoke(aR);
          // whatever you needto do to handle timeout
       }
                    

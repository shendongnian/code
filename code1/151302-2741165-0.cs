    while (WaitHandle.WaitAny(CommandEventArr) != 1))
    {
       lock (PendingOrders)
       {
          if (PendingOrders.Count > 0)
          {
              fbo = PendingOrders.Dequeue();
          }
          else
          {
              fbo = null;
                
              //Only if you want to exit when there are no more PendingOrders
              return;
          }
       }
       // Do Some Work if fbo is != null
    }

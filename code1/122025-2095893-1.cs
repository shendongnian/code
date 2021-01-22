     using (var mre = new ManualResetEvent(false))
     {
          int remainingToProcess = workItems.Count(); // Assuming workItems is a collection of "tasks"
          foreach(var item in workItems)
          {
               // delegate closure below will capture a reference to 'item', resulting in
               // the incorrect item sent to ProcessTask each iteration.  Use a local copy
               // of the 'item' variable instead.
               var localItem = item;
               ThreadPool.QueueUserWorkItem(delegate
               {
                   // Replace this with your "work"
                   ProcessTask(localItem);
                   // This will (safely) decrement the remaining count, and allow the main thread to continue when we're done
                   if (Interlocked.Decrement(ref remainingToProcess) == 0)
                          mre.Set();
               });
          }
          mre.WaitOne();
     }

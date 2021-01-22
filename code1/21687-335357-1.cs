//shared state
private Queue<Item> workQueue;
private EventWaitHandle eventHandle;
//method running in gui thread
private void DoWork(Item itemToProcess)
{
   //use a private lock object instead of lock...
   lock(this.workQueue)
   {
       this.workQueue.Add(itemToProcess);
       this.eventHandle.Set();
   }
}
//method that runs on the background thread
private void QueueMonitor()
{
   while(keepRunning)
   {
       //if the event handle is not signalled the processing thread will sleep here until it is signalled or the timeout expires
       if(this.eventHandle.WaitOne(optionalTimeout))
       {
           lock(this.workQueue)
           {
              while(this.workQueue.Count > 0)
              {
                 Item itemToProcess = this.workQueue.Dequeue();
                 //do something with item...
              }
           }
           //reset wait handle - note that AutoResetEvent resets automatically
           this.eventHandle.Reset();
       }
   }
}

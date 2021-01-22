public sealed class S3StoreLikePutFileWorker&lt;TYourData&gt; : BackgroundWorker
{
    private AutoResetEvent WakeUpEvent = new AutoResetEvent(false);
    private Queue&lt;TYourData&gt; DataQueue = new Queue&lt;TYourData&gt;();
    private volatile bool StopWork = false;
    public void PutFile(TYourData dataToWrite)
    {
        DataQueue.Enqueue(dataToWrite);
        WakeUpEvent.Set();
    }
    public void Close()
    {
        StopWork = true;
        WakeUpEvent.Set();
    }
    private override void OnDoWork(DoWorkEventArgs e)
    {
        do
        {
            // sleep until there is something to do
            WakeUpEvent.WaitOne();
            if(StopWork) break;
            // Write data, if available
            while(DataQueue.Count > 0)
            {
                TYourData yourDataToWrite = DataQueue.Dequeue();
                // write data to file
            }
        }
        while(!StopWork);
    }
}

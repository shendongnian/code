    protected ManualResetEvent threadStop = new ManualResetEvent(false);
    protected void ReadData()
    {
         SerialPort serialPort = null;
         try
         {
             serialPort = SetupSerialPort(_serialPortSettings);
             serialPort.Open();
         
             string data;
             while (serialPort.IsOpen)
             {
                 try
                 {
                     
                     data = serialPort.ReadLine();
                     if (data.Length > 0)
                         ReceivedData(serialPort, new ReceivedDataEventArgs(data));
                     
                 }
                 catch (TimeoutException)
                 {
                     //  No action
                 }
                 // WaitOne(0) tests whether the event was set and returns TRUE
                 //   if it was set and FALSE otherwise.
                 // The 0 tells the manual reset event to only check if it was set
                 //   and return immediately, otherwise if the number is greater than
                 //   0 it will wait for that many milliseconds for the event to be set
                 //   and only then return - effectively blocking your thread for that
                 //   period of time
                 if (threadStop.WaitOne(0))
                     break;
             }
         }
         catch (Exception exc)
         {
             // you can do something here in case of an exception
             // but a ThreadAbortedException should't be thrown any more if you
             // stop using Thread.Abort and rely on the ManualResetEvent instead
         }
         finally
         {
             if (serialPort != null)
                 serialPort.Close();
         }
    }
    protected void Stop()
    {
        // Set the manual reset event to a "signaled" state --> will cause the
        //   WaitOne function to return TRUE
        threadStop.Set();
    } 

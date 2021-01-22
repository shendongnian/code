    protected ManualResetEvent threadStop = new New ManualResetEvent(False);
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
                 // WaitOne(0) tests whether the event was set and returns true
                 //  if it was set, false otherwise
                 if(threadStop.WaitOne(0))
                     break;
             }
         }
         catch (Exception)
         {
         }finally
         {
             if (serialPort != null)
                 serialPort.Close();
         }
    }
    protected void Stop()
    {
        threadStop.Set();
    } 

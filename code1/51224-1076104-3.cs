    while(bRunningReadTrhead)
{
          try
          {
              string message = _serialPort.ReadLine();
          }
          catch(Exception e)
          {
             Console.Write(e);
          }
       }
       

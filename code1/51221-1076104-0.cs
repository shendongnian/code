    while(bRunningReadTrhead)
       {
          try{string message = _serialPort.ReadLine();}
          catch(Exception e){Console.Write(e);}
       }
       // exits a worker thread when you set global bool in false

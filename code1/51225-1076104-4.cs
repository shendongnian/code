    // is this a local definition of _readThread var in constructor? 
    // if so, after some time  gabbage collector clear this var from memory, a disposed object 
    // shouldnot work (there is no such an object in memory). 
    // The same with SerialPort local var 
    // To work properly you should somewhere in class define a member 
    
    class foo
    {
       // ...
       Thread _readThread;
       SerialPort _serialPort;
       bool bRunningReadTrhead=false;
    
       //...
    
       // which is static or instanced, than
    
       public foo()
       {
          // ...
          _serialPort = new SerialPort("COM1", 9600);
          _serialPort.Parity = Parity.None;
          _serialPort.DataBits = 8;
          _serialPort.StopBits = StopBits.One;
          _serialPort.Handshake = Handshake.None;
          _serialPort.DtrEnable = true;
          _serialPort.Open();
          _readThread = new Thread(Read);
          
          bRunningReadTrhead=true;
    
          _readThread.Start();
    
          //...
       }
       
       // creates a thread which will live a long time in loop:
       private void Read()
       {
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
           
          // exits a worker thread when you set global bool in false
         }
     
        // ...
    }
    
    // if you do not set a loop the thread  also finish   all jobs and become disposed

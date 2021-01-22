    //from top of the head;
    
    using System.Port.IO;
    using System.Port;
    
    private class mywindowsForm: Form
    {
          StringBuilder sbReceived = new StringBuilder();
          string Received = string.Empty;
          int byteCOUNT = 0;
          
          System.Windows.Timers.Timer serialTimer;
    
          //Default constructor 
          myWindowsForm()
          {
             //assume that you clicked and dragged serial port in
              serialPort1 = new SerialPort();//create new serial port instance 
              serialPort1.Baud = 9600;
              serialPort1.DataReceived+=<Tab><Enter>
              //serial port timer 
              serialTimer = new System.Windows.Timers.Timer(500);//set to 500ms time delay
              serialTimer.Elapsed+=<TAB><ENTER>
          }
    
          void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
          {
               //serial port has detected input data
               //however, we only want to get serial data so,
               if(e.EventType !=SerialData.Chars) return;
               //good design practice dictates that we have an event handler that we invoke
                this.BeginInvoke(new eventhandler(AddReceive));//beginInvoke is designed to deal with asynchronous processes like serial port data. 
          }
          
          private void AddReceive(object s, EventArg e)
          {
                byteCOUNT=serialPort1.BytesToRead;//count the number of bytes in RX buffer
                if(byteCOUNT > 0) 
                 {
                     string ST = serialPort1.ReadTo("\n");//lets get one line at a time 
                     sbReceived.Append(ST);//add whatever has been RX'd to our container. 
                     serialPort1.Interval =100;
                     serialPort1.Start();//to be sure we have all data, check to see for stragglers.
                  }
          }
    
           void serialTimer(object Sender, TimerElapsedEventArgs e)
           {
                serialTimer.Stop();
                this.BeginInvoke(new EventHandler(ReadData));
            }
    
           void ReadData(object Sender, EventArgs e)
           {
                //parse output for required data and output to terminal display (build one using rich text box)
                 Received = sbReceived.ToString();
                 //and if we have ANY MORE incoming data left over in serial buffer
                  if(Received.Length > 0)
                  {
                      //your data 
                  }
           }
    }

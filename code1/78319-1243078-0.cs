    using System;
    using System.IO.Ports;
    using System.Windows.Forms;
    namespace SerialPortExample
    {
      class SerialPortProgram
      {
        // Create the serial port with basic settings
        private SerialPort port = new SerialPort("COM1",
          9600, Parity.None, 8, StopBits.One);
    
        [STAThread]
        static void Main(string[] args)
        { 
          // Instatiate this class
          new SerialPortProgram();
        }
    
        private SerialPortProgram()
        {
          Console.WriteLine("Incoming Data:");
    
          // Attach a method to be called when there
          // is data waiting in the port's buffer
          port.DataReceived += new 
            SerialDataReceivedEventHandler(port_DataReceived);
    
          // Begin communications
          port.Open();
          
          // Enter an application loop to keep this thread alive
          Application.Run();
        }
    
        private void port_DataReceived(object sender,
          SerialDataReceivedEventArgs e)
        {
          // Show all the incoming data in the port's buffer
          Console.WriteLine(port.ReadExisting());
        }
      }
    }

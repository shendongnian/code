    namespace serialPortCollection
    {   class Program
        {
            static void Main(string[] args)
            {
                SerialPort sp = new SerialPort("COM10", 115200);
                sp.DataReceived += port_OnReceiveDatazz; // Add DataReceived Event Handler
    
                sp.Open();
                sp.WriteLine("$"); //Command to start Data Stream
    
                Console.ReadLine();
    
                sp.WriteLine("!"); //Stop Data Stream Command
                sp.Close();
            }
    
           // My Event Handler Method
            private static void port_OnReceiveDatazz(object sender, 
                                       SerialDataReceivedEventArgs e)
            {
                SerialPort spL = (SerialPort) sender;
                byte[] buf = new byte[spL.BytesToRead];
                Console.WriteLine("DATA RECEIVED!");
                spL.Read(buf, 0, buf.Length);
                foreach (Byte b in buf)
                {
                    Console.Write(b.ToString());
                }
                Console.WriteLine();
            }
        }
    }

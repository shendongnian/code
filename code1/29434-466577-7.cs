    namespace TestApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                Thread writeThread = new Thread(new ThreadStart(WriteThread));
                SerialPort sp = new SerialPort("COM33", 115200, Parity.None, 8, StopBits.One);
                sp.DataReceived += port_OnReceiveDatazz; // Add DataReceived Event Handler
    
                sp.Open();
                sp.WriteLine("$"); //Command to start Data Stream
    
                writeThread.Start();
    
                Console.ReadLine();
    
                sp.WriteLine("!"); //Stop Data Stream Command
                sp.Close();
            }
    
            private static void port_OnReceiveDatazz(object sender, 
                                       SerialDataReceivedEventArgs e)
            {
                SerialPort spL = (SerialPort) sender;
                byte[] buf = new byte[spL.BytesToRead];
                Console.WriteLine("DATA RECEIVED!");
                spL.Read(buf, 0, buf.Length);
                foreach (Byte b in buf)
                {
                    Console.Write(b.ToString() + " ");
                }
                Console.WriteLine();
            }
    
            private static void WriteThread()
            {
                SerialPort sp2 = new SerialPort("COM34", 115200, Parity.None, 8, StopBits.One);
                sp2.Open();
                byte[] buf = new byte[100];
                for (byte i = 0; i < 100; i++)
                {
                    buf[i] = i;
                }
                sp2.Write(buf, 0, buf.Length);
                sp2.Close();
            }
        }
    }

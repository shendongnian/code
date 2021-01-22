        using (SerialPort port = new SerialPort("COM1", 9600))
        {
            while (true)
            {
                Thread.Sleep(1000);
                try
                {
                    Console.Write("Open...");
                    port.Open();
                    port.DtrEnable = true;
                    Thread.Sleep(1000);
                    port.Close();
                    Console.WriteLine("Close");
                }
                catch
                {
                    Console.WriteLine("Error opening serial port");
                }
                finally
                {
                    if (port.IsOpen)
                        port.Close();
                }
            }
        }

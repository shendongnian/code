    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.IO.Ports;
    namespace SerialPortExperiments
    {
        class Program
        {
            public static void Main()
            {
                // Create a new SerialPort object with default settings.
                SerialPort _serialPort = new SerialPort();
                // Set some generic settings
                SetBasicSettings(ref _serialPort);
                // Try and find something valid
                int baudRate = FindValidBaud(ref _serialPort);
                if (baudRate > 0)
                {
                    Console.WriteLine(String.Format("Found baudrate: {0}", baudRate));
                }
                else
                {
                    Console.WriteLine("ERROR: Failed to identify baudrate");
                }
            }
            public static void SetBasicSettings(ref SerialPort port)
            {
                port.PortName = "COM1";
                port.Parity = Parity.None;
                port.DataBits = 8;
                port.StopBits = 0;
                port.Handshake = Handshake.None;
                port.ReadTimeout = 500;
                port.WriteTimeout = 500;
            }
            public static int FindValidBaud(ref SerialPort port)
            {
                bool buadrateIdentified = false;
                // Pick some baudrates to try
                List<int> baudrates = new List<int>();
                baudrates.Add(9600);
                baudrates.Add(19200);
                // Try and open the port at each baud rate in turn, trying one write/read to verify success
                for (int i = 0; i < baudrates.Count; i++)
                {
                    // Pick a baud rate
                    port.BaudRate = baudrates[i];
                    // Try opening a connection and exchanging some data
                    port.Open();
                    buadrateIdentified = AttemptValidExchange(ref port);
                    port.Close();
                    if (buadrateIdentified)
                    {
                        return port.BaudRate;
                    }
                }
                return -1;
            }
            public static bool AttemptValidExchange(ref SerialPort port)
            {
                try
                {
                    // Send a test command
                    port.Write("SOME_TEST_COMMAND");
                    // Check to see what the device responded with
                    const int expectedReturnLength = 1024;
                    byte[] buffer = new byte[expectedReturnLength];
                    port.Read(buffer, 0, expectedReturnLength);
                    if (buffer.ToString().Equals("EXPECTED_RETURN_VALUE"))
                    {
                        return true;
                    }
                }
                catch (TimeoutException) // NOTE: You'll probably need to catch other exceptions like parity errors here
                {
                }
                return false;
            }
        }
    }

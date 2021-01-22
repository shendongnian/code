    using System;
    using System.IO.Ports;
    using System.Collections.Generic;
    using System.Text;
    namespace SerPort1
    {
    class Program
    {
        static private SerialPort MyPort;
        static void Main(string[] args)
        {
            MyPort = new SerialPort("COM1");
            OpenMyPort();
            Console.WriteLine("BaudRate {0}", MyPort.BaudRate);
            OpenMyPort();
            MyPort.Close();
            Console.ReadLine();
        }
        private static void OpenMyPort()
        {
            try
            {
                MyPort.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error opening my port: {0}", ex.Message);
            }
        }
      }
    }

namespace Vurdalakov
{
    using System;
    using RJCP.IO.Ports;
    class Program
    {
        static void Main(String[] args)
        {
            using (var serialPort = new SerialPortStream("COM1"))
            {
                serialPort.OpenDirect();
                while (serialPort.IsOpen)
                {
                    var ch = (Char)serialPort.ReadChar();
                    Console.Write(ch);
                }
            }
        }
    }
}

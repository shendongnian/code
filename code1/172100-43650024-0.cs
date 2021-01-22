    static void Main(string[] args)
    {
        using (var output = Console.OpenStandardOutput())
        using (var serialPort = new SerialPort(args[0], int.Parse(args[1])))
        {
            serialPort.Open();
            while (serialPort.IsOpen)
            {
                serialPort.BaseStream.CopyTo(output);
            }
        }
    }

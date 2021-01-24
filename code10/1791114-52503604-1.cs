    string[] ports = SerialPort.GetPortNames();    // get all the available port names in string array
    if (ports.Length > 0)
    {
        // create SerialPort object 
        SerialPort sp = new SerialPort(ports[0], 2400, Parity.Even, 7, StopBits.One);
        sp.Open();
        string str = "";
        // infinite loop to read data byte by byte. you can also use for loop to read constant amount of bytes
        while (true)
        {
            // sp.ReadByte is blocking read, it will wait until a byte is available for reading
            byte data = (byte)sp.ReadByte();
            Console.Write(" "+data);
            str += data + " ";
        }
        sp.Close();
    }

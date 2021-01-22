    foreach(string portname in SerialPort.GetPortNames())
    {
        // Use your connection settings - own baud rate etc
        SerialPort sp = new SerialPort(portname,4800, Parity.Odd, 8, StopBits.One); 
        try
        {
             sp.Open();
             sp.Write("Your known command to phone");
             Thread.Sleep(500);
             string received = sp.ReadLine();
             if(received == "expected response")
             {
                  Console.WriteLine("Phone connected to: " + portname);
                  break;
             }
        }
        catch(Exception)
        {
             Console.WriteLine("Phone NOT connected to: " + portname);
        }
        finally
        {
             sp.Close();
        }
    }
